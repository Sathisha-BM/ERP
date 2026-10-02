using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Services
{
    public sealed class EmptyHttpContextAccessor : IHttpContextAccessor
    {
        public HttpContext? HttpContext
        {
            get => null;
            set { }
        }
    }
}
