using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.QIMSViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IQimsIsoService
{
    public interface IQimsService
    {
        Task<QmsDocumentVM> UpsertQimsAsync(QmsDocumentVM labourgrnVM, int screenCode);
        Task<int> GetScreenCodeByScreenNameAsync(string screenName);
        Task<QmsDocumentHeaderVM> UpsertHeadersAsync(QmsDocumentHeaderVM QmsDocumentHeaderVMs, int screenCode);

        Task<List<QmsDocumentVM>> GetAllDocumentsAsync();

        Task<List<QmsDocumentHeaderVM>> GetAllHeadersAsync();
        Task<List<QmsDocumentVM>> GetExpiredDocumentsAsync();
        Task DeleteAndResequenceAsync(QmsDocumentVM subitem, int screenCode);
        Task DeleteHeaderAsync(int headerId, int screenCode);
        Task<List<QmsDocumentVM>> GetExpiredDocuments5daysAsync();
    }
}
