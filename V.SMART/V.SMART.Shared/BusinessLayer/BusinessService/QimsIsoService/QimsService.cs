using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IQimsIsoService;
using V.SMART.Shared.Data.QMSISO;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.QIMSViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.QimsIsoService
{
    public class QimsService : IQimsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;
      
        private readonly IExcelTemplateService _excelTemplateService;


        public QimsService(
            IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
          
            ILoggingService logs,
            IMapper mapper,
            IExcelTemplateService excelTemplateService)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _mapper = mapper;
            _excelTemplateService = excelTemplateService;

        }

        public async Task<int> GetScreenCodeByScreenNameAsync(string screenName)
         => await _commonService.GetScreenCodeByScreenNameAsync(screenName);

        public async Task<QmsDocumentVM> UpsertQimsAsync(QmsDocumentVM QmsDocumentVMs, int screenCode)
        {
            if (QmsDocumentVMs == null)
                throw new ArgumentNullException(nameof(QmsDocumentVMs));

            var now = DateTime.Now;
            var currentUser = await _currentUserService.GetUsernameAsync();
            var changes = new StringBuilder();
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                QmsDocument entity;
                if (QmsDocumentVMs.DocumentId == 0)
                {
                    entity = _mapper.Map<QmsDocument>(QmsDocumentVMs);
                 
                    entity.CreatedBy = currentUser;
                    entity.CreatedDate = now;
                  
                    await _unitOfWork.QmsDocuments.CreateAsync(entity);
                    await _unitOfWork.SaveAsync();

                    changes.AppendLine("QIMS Document Created.");
                }
                else
                {
                    entity = await _unitOfWork.QmsDocuments.GetQueryable()
                        .FirstOrDefaultAsync(q => q.DocumentId == QmsDocumentVMs.DocumentId)
                        ?? throw new InvalidOperationException("QIMS Document found.");

                    var parentChanges = GetPropertyChanges(entity, QmsDocumentVMs);
                    if (!string.IsNullOrEmpty(parentChanges))
                        changes.AppendLine("Parent Changes:\n" + parentChanges);

                    _mapper.Map(QmsDocumentVMs, entity);
               
                 
                    changes.AppendLine("QIMS Document Updated.");
                }

                await _unitOfWork.SaveAsync();



                await transaction.CommitAsync();

                await LogChangesAsync(changes, QmsDocumentVMs.DocumentId == 0 ? "QIMS Document Created" : "QIMS Document  Updated");

                var savedEntity = await _unitOfWork.QmsDocuments.GetQueryable()
                    .AsNoTracking()
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(q => q.DocumentId == entity.DocumentId);

                return _mapper.Map<QmsDocumentVM>(savedEntity!);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await _logs.LogDeveloperError(ex, $"Failed to upsert QIMS Document: {QmsDocumentVMs.DocumentId}");
                throw new InvalidOperationException("Failed to save QIMS Document. Please try again.");
            }
        }

        public async Task<QmsDocumentHeaderVM> UpsertHeadersAsync(QmsDocumentHeaderVM QmsDocumentHeaderVMs, int screenCode)
        {
            if (QmsDocumentHeaderVMs == null)
                throw new ArgumentNullException(nameof(QmsDocumentHeaderVMs));

            var now = DateTime.Now;
            var currentUser = await _currentUserService.GetUsernameAsync();
            var changes = new StringBuilder();
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                QmsDocumentHeader entity;
                if (QmsDocumentHeaderVMs.HeaderId == 0)
                {
                    entity = _mapper.Map<QmsDocumentHeader>(QmsDocumentHeaderVMs);

                    entity.CreatedBy = currentUser;
                    entity.CreatedDate = now; 

                    await _unitOfWork.QmsDocumentHeaders.CreateAsync(entity);
                    await _unitOfWork.SaveAsync();

                    changes.AppendLine("QIMS Document Created.");
                }
                else
                {
                    entity = await _unitOfWork.QmsDocumentHeaders.GetQueryable()
                        .FirstOrDefaultAsync(q => q.HeaderId == QmsDocumentHeaderVMs.HeaderId)
                        ?? throw new InvalidOperationException("QIMS headers found.");

                    var parentChanges = GetPropertyChanges(entity, QmsDocumentHeaderVMs);
                    if (!string.IsNullOrEmpty(parentChanges))
                        changes.AppendLine("Parent Changes:\n" + parentChanges);

                    _mapper.Map(QmsDocumentHeaderVMs, entity);


                    changes.AppendLine("QIMS Headers Updated.");
                }

                await _unitOfWork.SaveAsync();



                await transaction.CommitAsync();

                await LogChangesAsync(changes, QmsDocumentHeaderVMs.HeaderId == 0 ? "QIMS Headers Created" : "QIMS Headers  Updated");

                var savedEntity = await _unitOfWork.QmsDocumentHeaders.GetQueryable()
                    .AsNoTracking()
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(q => q.HeaderId == entity.HeaderId);

                return _mapper.Map<QmsDocumentHeaderVM>(savedEntity!);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await _logs.LogDeveloperError(ex, $"Failed to upsert QIMS Headers: {QmsDocumentHeaderVMs.HeaderId}");
                throw new InvalidOperationException("Failed to save QIMS Headers. Please try again.");
            }
        }
        private string GetPropertyChanges<TSource, TTarget>(TSource entity, TTarget vm)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (var prop in typeof(TSource).GetProperties())
                {
                    var vmProp = typeof(TTarget).GetProperty(prop.Name);
                    if (vmProp == null) continue;

                    var oldVal = prop.GetValue(entity)?.ToString() ?? "null";
                    var newVal = vmProp.GetValue(vm)?.ToString() ?? "null";

                    if (oldVal != newVal)
                        sb.AppendLine($"{prop.Name}: '{oldVal}' → '{newVal}'");
                }
                return sb.ToString();

            }
            catch (Exception ex)
            {

                _logs.LogDeveloperError(ex, $"Failed to GetPropertyChanges in QIMS Documnet");
                return null;
            }
        }

        private async Task LogChangesAsync(StringBuilder changes, string action)
        {
            try
            {
                if (changes.Length == 0) return;

                await _logs.LogUserAction(
                    UserName: await _currentUserService.GetUsernameAsync(),
                    Machine: _currentUserService.MachineName,
                    IP_Address: _currentUserService.IpAddress,
                    screen: "QIMS",
                    action: action,
                    additionalInfo: changes.ToString()
                );

            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Failed to LogChangesAsync in QIMS Document");
            }
        }

        public async Task<List<QmsDocumentVM>> GetAllDocumentsAsync()
        {
            var list = await _unitOfWork.QmsDocuments
                .GetQueryable()
                .AsNoTracking()
                .OrderBy(x => x.DocumentId)
                .ToListAsync();

            return _mapper.Map<List<QmsDocumentVM>>(list);
        }
        public async Task<List<QmsDocumentHeaderVM>> GetAllHeadersAsync()
        {
            var list = await _unitOfWork.QmsDocumentHeaders
                .GetQueryable()
                .AsNoTracking()
                .OrderBy(x => x.HeaderId)
                .ToListAsync();

            return _mapper.Map<List<QmsDocumentHeaderVM>>(list);
        }
        public async Task<List<QmsDocumentVM>> GetExpiredDocumentsAsync()
        {
            var documents = await _unitOfWork.QmsDocuments.GetQueryable()
                .Where(x => x.ExpiryDate.HasValue &&
                            x.ExpiryDate.Value.Date < DateTime.Today)
                .ToListAsync();

            return _mapper.Map<List<QmsDocumentVM>>(documents);
        }
        public async Task<List<QmsDocumentVM>> GetExpiredDocuments5daysAsync()
        {
            var today = DateTime.Today;
            var warningDate = today.AddDays(5);

            var documents = await _unitOfWork.QmsDocuments.GetQueryable()
                .Where(x => x.ExpiryDate.HasValue &&
                            x.ExpiryDate.Value.Date <= warningDate)
                .OrderBy(x => x.ExpiryDate)
                .ToListAsync();

            return _mapper.Map<List<QmsDocumentVM>>(documents);
        }

        public async Task DeleteAndResequenceAsync(QmsDocumentVM subitem, int screenCode)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
               
                if (subitem.DocumentId > 0)
                {
                    var entity = await _unitOfWork.QmsDocuments.GetAsync(subitem.DocumentId);

                    if (entity == null)
                        throw new InvalidOperationException("Sub item not found.");

                        // Delete selected OUT item
                        await _unitOfWork.QmsDocuments.DeleteAsync(entity.DocumentId);
                        await _unitOfWork.SaveAsync();

                
                    await _logs.LogUserAction(
                        await _currentUserService.GetUsernameAsync(),
                        _currentUserService.MachineName,
                        _currentUserService.IpAddress,
                        "QIMS Doccumnet",
                        $"Deleted Qims Doc Name: {subitem.DocumentName}",
                        $"QIMS Doc No: {subitem?.DocumentNo}");
                }
              

                // Resequence SlNo
                var remaining = await _unitOfWork.QmsDocuments
                    .GetQueryable()
                    .Where(x => x.DocumentId == subitem.DocumentId)
                    .OrderBy(x => x.DocumentId)
                    .ToListAsync();


                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await _logs.LogDeveloperError(ex, $"Failed to upsert QIMS Headers: {subitem.DocumentId}");
                throw new InvalidOperationException("Failed to save QIMS Headers. Please try again.");
            }
        }

        public async Task DeleteHeaderAsync(int headerId, int screenCode)
        {
            try
            {
                var header = await _unitOfWork.QmsDocumentHeaders
                                          .GetQueryable()
                                          .FirstOrDefaultAsync(x => x.HeaderId == headerId);

                if (header == null)
                    return;

               await _unitOfWork.QmsDocumentHeaders.DeleteAsync(header);

                await _unitOfWork.SaveAsync();

                await _logs.LogUserAction(
                       await _currentUserService.GetUsernameAsync(),
                       _currentUserService.MachineName,
                       _currentUserService.IpAddress,
                       "QIMS Header",
                       $"Deleted Qims Header Name: {header.HeaderName}",
                       $"QIMS Header No: {header?.HeaderId}");
            }
            catch (Exception ex)
            {
                _logs.LogDeveloperError(ex, $"Failed to DeleteHeaderAsync in QIMS Documnet");
             
            }
        }
    }
}
