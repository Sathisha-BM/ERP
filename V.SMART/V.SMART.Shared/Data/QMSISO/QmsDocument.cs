using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Data.QMSISO
{
    public class QmsDocument
    {
        [Key]
        public int DocumentId { get; set; }
        public int HeaderId { get; set; }

        [ForeignKey(nameof(HeaderId))]
        public QmsDocumentHeader? QmsDocumentHeader { get; set; }
        public string DocumentNo { get; set; } = "";
        public string DocumentName { get; set; } = "";
        public string RevisionNo { get; set; } = "Rev-00";
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ReviewDueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string FileName { get; set; } = "";
        public string? FileType { get; set; }
        public byte[]? FileContent { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public string? Status { get; set; } = "Active";
    }
}
