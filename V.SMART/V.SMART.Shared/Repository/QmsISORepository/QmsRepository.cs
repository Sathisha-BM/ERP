using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.QMSISO;
using V.SMART.Shared.Repository.IRepositor.IQmsISORepository;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.QmsISORepository
{
    internal class QmsRepository : Repository<QmsDocument>, IQmsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILoggingService _logs;
        private readonly CurrentUserService _currentUserService;

        public QmsRepository(ApplicationDbContext db, ILoggingService logs, CurrentUserService currentUserService) : base(db, logs)
        {
            _db = db;
            _logs = logs;
            _currentUserService = currentUserService;
        }
    }
    internal class QmsDocumentHeaderRepository : Repository<QmsDocumentHeader>, IQmsDocumentHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILoggingService _logs;
        private readonly CurrentUserService _currentUserService;

        public QmsDocumentHeaderRepository(ApplicationDbContext db, ILoggingService logs, CurrentUserService currentUserService) : base(db, logs)
        {
            _db = db;
            _logs = logs;
            _currentUserService = currentUserService;
        }
    }
}
