using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.QMSISO;
using V.SMART.Shared.Repository.IRepository;

namespace V.SMART.Shared.Repository.IRepositor.IQmsISORepository
{
    public interface IQmsRepository : IRepository<QmsDocument>
    {

    }

    public interface IQmsDocumentHeaderRepository : IRepository<QmsDocumentHeader>
    {

    }

}
