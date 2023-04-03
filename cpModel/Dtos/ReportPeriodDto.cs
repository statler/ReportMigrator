using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public partial class ReportPeriodDto
    {
        public int ReportPeriodId { get; set; }
        public string ReportPeriodName { get; set; }
        public DateTime? ClaimDate { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public bool? LockOut { get; set; }
        public int? LatestClaimVersionId { get; set; }

        public ProgressClaimVersionDto ActiveVersion { get; set; }
    }
}
