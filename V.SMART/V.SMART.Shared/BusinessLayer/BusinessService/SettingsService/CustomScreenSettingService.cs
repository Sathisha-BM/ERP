using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.ISettingsService;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels;
using V.SMART.Shared.ViewModels.CustomScreenViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.SettingsService
{
    public class CustomScreenSettingService : ICustomScreenSettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;

        private readonly IExcelTemplateService _excelTemplateService;
        public CustomScreenSettingService(IUnitOfWork unitOfWork,ICommonService commonService, CurrentUserService userService,ILoggingService logs,IMapper mapper,IExcelTemplateService excelTemplateService)
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

        public async Task<CustomScreenSettingVM> UpsertCustomScreenAsync(CustomScreenSettingVM CustomScreenSettingVMs, int screenCode)
        {
            if (CustomScreenSettingVMs == null)
                throw new ArgumentNullException(nameof(CustomScreenSettingVMs));

            var now = DateTime.Now;
            var currentUser = await _currentUserService.GetUsernameAsync();
            var changes = new StringBuilder();
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                CustomScreenSetting entity;

                if (CustomScreenSettingVMs.CustomId == 0)
                {
                    entity = _mapper.Map<CustomScreenSetting>(CustomScreenSettingVMs);

                    entity.CreatedBy = currentUser;
                    entity.CreatedDate = now;

                    await _unitOfWork.CustomScreenSettings.CreateAsync(entity);
                    await _unitOfWork.SaveAsync();

                    changes.AppendLine("CustomScreenSettings Header Created.");
                }
                else
                {
                    entity = await _unitOfWork.CustomScreenSettings.GetQueryable()
                        .FirstOrDefaultAsync(q => q.CustomId == CustomScreenSettingVMs.CustomId);

                       
                    var parentChanges = GetPropertyChanges(entity, CustomScreenSettingVMs);
                    if (!string.IsNullOrEmpty(parentChanges))
                        changes.AppendLine("Parent Changes:\n" + parentChanges);

                    _mapper.Map(CustomScreenSettingVMs, entity);


                    changes.AppendLine("CustomScreenSettings Header Updated.");
                }

                await _unitOfWork.SaveAsync();



                await transaction.CommitAsync();

                await LogChangesAsync(changes, CustomScreenSettingVMs.CustomId == 0 ? "CustomScreenSettings Header Created" : "CustomScreenSettings Header  Updated");

                var savedEntity = await _unitOfWork.CustomScreenSettings.GetQueryable()
                    .AsNoTracking()
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(q => q.CustomId == entity.CustomId);

                return _mapper.Map<CustomScreenSettingVM>(savedEntity!);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await _logs.LogDeveloperError(ex, $"Failed to upsert CustomScreenSettings Header: {CustomScreenSettingVMs.CustomId}");
                throw new InvalidOperationException("Failed to save CustomScreenSettings Header. Please try again.");
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

                _logs.LogDeveloperError(ex, $"Failed to GetPropertyChanges in CustomScreenSettings Header");
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
                    screen: "CustomScreenSettings",
                    action: action,
                    additionalInfo: changes.ToString()
                );

            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Failed to LogChangesAsync in CustomScreenSettings Header");
            }
        }

        public async Task<List<CustomScreenSettingVM>> GetAllCustomScreenAsync()
        {
                var customScreens = await _unitOfWork.CustomScreenSettings
            .GetQueryable()
            .AsNoTracking()
            .OrderBy(x => x.CustomId)
            .ToListAsync();

                var screens = await _unitOfWork.Screens
                    .GetQueryable()
                    .AsNoTracking()
                    .ToDictionaryAsync(x => x.Id);

                var result = customScreens.Select(x => new CustomScreenSettingVM
                {
                    CustomId = x.CustomId,
                    Header = x.Header,
                    CustomChildId = x.CustomChildId,
                    ScreenId = x.ScreenId,
                    Icon = x.Icon,
                    Color = x.Color,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,

                    ScreenName = screens.TryGetValue(x.ScreenId, out var screen)
                                    ? screen.ScreenName
                                    : string.Empty,

                    Navigation = screens.TryGetValue(x.ScreenId, out screen)
                                    ? screen.Navigation
                                    : string.Empty
                }).ToList();

                return result;
        }
       
        public async Task DeleteAndResequenceAsync(CustomScreenSettingVM subitem, int screenCode)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {

                if (subitem.CustomId > 0)
                {
                    var entity = await _unitOfWork.CustomScreenSettings.GetAsync(subitem.CustomId);

                    if (entity == null)
                        throw new InvalidOperationException("Sub item not found.");

                    // Delete selected OUT item
                    await _unitOfWork.CustomScreenSettings.DeleteAsync(entity.CustomId);
                    await _unitOfWork.SaveAsync();


                    await _logs.LogUserAction(
                        await _currentUserService.GetUsernameAsync(),
                        _currentUserService.MachineName,
                        _currentUserService.IpAddress,
                        "CustomScreenSettings Header",
                        $"Deleted CustomScreenSettings Header Name: {subitem.Header}",
                        $"CustomScreenSettings Header No: {subitem?.CustomId}");
                }


                // Resequence SlNo
                var remaining = await _unitOfWork.CustomScreenSettings
                    .GetQueryable()
                    .Where(x => x.CustomId == subitem.CustomId)
                    .OrderBy(x => x.CustomId)
                    .ToListAsync();


                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await _logs.LogDeveloperError(ex, $"Failed to upsert CustomScreenSettings Headers: {subitem.CustomId}");
                throw new InvalidOperationException("Failed to save CustomScreenSettings Headers. Please try again.");
            }
        }

        public async Task<List<CustomScreenSettingVM>> GetAllHeadersAsync()
        {
            var list =  await (
            from c in _unitOfWork.CustomScreenSettings.GetQueryable().AsNoTracking()

            join s in _unitOfWork.Screens.GetQueryable().AsNoTracking()
                on c.ScreenId equals s.Id into screenGroup

            from s in screenGroup.DefaultIfEmpty() // LEFT JOIN

            orderby c.CustomId

            select new CustomScreenSettingVM
            {
                CustomId = c.CustomId,
                Header = c.Header,
                CustomChildId = c.CustomChildId,
                ScreenId = c.ScreenId,

                ScreenName = s != null ? s.ScreenName : string.Empty,
                Navigation = s != null ? s.Navigation : string.Empty,

                CreatedBy = c.CreatedBy,
                CreatedDate = c.CreatedDate,
                ModifiedBy = c.ModifiedBy,
                ModifiedDate = c.ModifiedDate
            })
            .ToListAsync();

            return _mapper.Map<List<CustomScreenSettingVM>>(list);
        }

        public async Task<List<ScreensVM>> GetAllScreensAsync()
        {
            return await _unitOfWork.Screens
                .GetQueryable()
                .AsNoTracking()
                .OrderBy(x => x.ScreenCode)
                .Select(x => new ScreensVM
                {
                    Id = x.Id,
                    ScreenCode = x.ScreenCode,
                    ScreenName = x.ScreenName,
                    Navigation = x.Navigation,
                    IsPrintRequired = x.IsPrintRequired
                })
                .ToListAsync();
        }

        public async Task DeleteHeaderAsync(int CustomId, int screenCode)
        {
            try
            {
                var header = await _unitOfWork.CustomScreenSettings
                                          .GetQueryable()
                                          .FirstOrDefaultAsync(x => x.CustomId == CustomId);

                if (header == null)
                    return;

                await _unitOfWork.CustomScreenSettings.DeleteAsync(header);

                await _unitOfWork.SaveAsync();

                await _logs.LogUserAction(
                       await _currentUserService.GetUsernameAsync(),
                       _currentUserService.MachineName,
                       _currentUserService.IpAddress,
                       "CustomScreenSettings Header",
                       $"Deleted CustomScreenSettings Header Name: {header.Header}",
                       $"CustomScreenSettings Header No: {header?.CustomId}");
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Failed to DeleteHeaderAsync in CustomScreenSetting Documnet");

            }
        }


        public async Task<List<CustomScreenSettingVM>> GetNavigationMenuAsync()
        {
            try
            {
                var customSettings = await _unitOfWork.CustomScreenSettings.GetAllAsync();

                var screens = (await _unitOfWork.Screens.GetAllAsync())
                                .ToDictionary(x => x.Id);

                var menus = customSettings.Select(x => new CustomScreenSettingVM
                {
                    CustomId = x.CustomId,
                    CustomChildId = x.CustomChildId,
                    ScreenId = x.ScreenId,
                    Header = x.Header,
                    Icon = x.Icon,
                    Color = x.Color,
                    Navigation = x.ScreenId > 0 &&
                                 screens.ContainsKey(x.ScreenId)
                                    ? screens[x.ScreenId].Navigation
                                    : null
                }).ToList();

                //Create Tree
                var lookup = menus.ToDictionary(x => x.CustomId);

                foreach (var item in menus)
                {
                    if (item.CustomChildId > 0 && lookup.ContainsKey(item.CustomChildId))
                    {
                        lookup[item.CustomChildId].Children.Add(item);
                    }
                }

                return menus.Where(x => x.CustomChildId == 0).ToList();

            }
            catch (Exception ex)
            {

               await  _logs.LogDeveloperError(ex, $"Failed to DeleteHeaderAsync in QIMS Documnet");
                return new List<CustomScreenSettingVM>();
            }
        }

        public async Task<bool> IsCustomNavigationRequiredAsync()
        {
            try
            {
                return await _unitOfWork.ScreenManagements
                .GetQueryable()
                .Where(x => x.Id == 39 &&
                            x.ScreenName == "Custom Navigation")
                .Select(x => x.Required)
                .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
