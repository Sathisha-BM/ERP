using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign;
using V.SMART.Shared.Repository.IRepository.IHumanResourceRepository.IProcessEmployeeAssignRepository;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.HumanResourceRepository.ProcessEmployeeAssignRepository
{
    public class ProcessEmployeeAssignRepository : Repository<ProcessEmployeeAssign>, IProcessEmployeeAssignRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILoggingService _loggingService;
        private readonly CurrentUserService _currentUserService;
        public ProcessEmployeeAssignRepository(
            ApplicationDbContext db,
            ILoggingService loggingService,
            CurrentUserService currentUserService) : base(db, loggingService)
        {
            _db = db;
            _loggingService = loggingService;
            _currentUserService = currentUserService;
        }
                      

    }
}
