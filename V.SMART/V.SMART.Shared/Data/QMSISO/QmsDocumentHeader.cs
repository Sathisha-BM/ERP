using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Data.QMSISO
{
    public class QmsDocumentHeader
    {
        [Key]
        public int HeaderId { get; set; }

        [Required(ErrorMessage = "HeaderName is required.")]
        [StringLength(250, ErrorMessage = "HeaderName cannot exceed 250 characters.")]
        public string HeaderName { get; set; } = "";
        public int? ParentHeaderId { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
