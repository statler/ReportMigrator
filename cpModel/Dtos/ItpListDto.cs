using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class ItpListDto
    {
        public int ItpId { get; set; }
        public string Description { get; set; }
        public string SpecRef { get; set; }
        public string QvcDocnumber { get; set; }
        public string ItpDocnumber { get; set; }
        public DateTime? RevisionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? RevisionId { get; set; }
        public bool HasScheduleLink { get; set; }
    }
}
