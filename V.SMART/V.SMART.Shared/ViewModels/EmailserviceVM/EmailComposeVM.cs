using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.EmailserviceVM
{
    public class EmailComposeVM
    {
        public string FromEmail { get; set; }

        public string To { get; set; }

        public string CC { get; set; }

        public string BCC { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public byte[] AttachmentBytes { get; set; }

        public string AttachmentName { get; set; }

        public bool IsDefaultMail { get; set; } = false;
    }
}
