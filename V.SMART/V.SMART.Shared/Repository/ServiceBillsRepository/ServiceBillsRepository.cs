
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.CashFlow.ServiceBills;
using V.SMART.Shared.Repository;
using V.SMART.Shared.Repository.IRepository.ICashFlowRepository.IServiceBillsRepository;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.CashFlowRepository.ServiceBillsRepository
{
    public class ServiceBillsRepository:Repository<ServiceBills>, IServiceBillsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILoggingService _loggingService;
        private readonly CurrentUserService _currentUserService;

        public ServiceBillsRepository(ApplicationDbContext db, ILoggingService loggingService,CurrentUserService currentUserService) : base(db, loggingService)
        {
            _db = db;
            _loggingService = loggingService;
            _currentUserService = currentUserService;
        }

        public async Task<string> GetLastInvNoAsync(string suffix)
        {
            // Safely fetch the latest QuoteNo with locking to prevent concurrency issues
            var lastNumberStr = await _db.ServiceBills
                .FromSqlRaw(@"
            SELECT TOP 1 * 
            FROM ServiceBills WITH (UPDLOCK, ROWLOCK)
            WHERE Suffix = {0}
            ORDER BY TRY_CAST(InvNo AS INT) DESC", suffix)
                .Select(q => q.InvNo)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            // Ensure null safety before parsing
            if (!string.IsNullOrWhiteSpace(lastNumberStr) &&
                int.TryParse(lastNumberStr, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }

            return nextNumber.ToString();
        }
    }
}
