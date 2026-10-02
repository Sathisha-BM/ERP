using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.QMSISO;
using V.SMART.Shared.ViewModels.QIMSViewModel;

namespace V.SMART.Shared.Mappings.QIMSMapping
{
    public class QimsHeaderProfile : Profile
    {
        public QimsHeaderProfile()
        {
            CreateMap<QmsDocumentHeader, QmsDocumentHeaderVM>().ReverseMap();

        }

    }
    public class QimsDocsProfile : Profile
    {
        public QimsDocsProfile()
        {
            CreateMap<QmsDocument, QmsDocumentVM>().ReverseMap();

        }

    }

}
