using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign;
using V.SMART.Shared.Repository.IRepository.IProductionRepository.IProductionAttendanceRepo;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.ProductionRepository.ProductionAttendance
{
	public class ProductionAttendancelogRepository:Repository<ProductionAttendancelog>, IProductionAttendancelogRepository
    {
		private readonly ApplicationDbContext _db;
		private readonly ILoggingService _logs;
		private readonly CurrentUserService _currentUserService;
		public ProductionAttendancelogRepository(ApplicationDbContext db, ILoggingService logs, CurrentUserService userService) : base(db, logs)
		{
			_db = db;
			_logs = logs;
			_currentUserService = userService;

		}

	}
}
