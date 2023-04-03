using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public class ScheduleFlatReportDto : ScheduleFlatDto
    {
        public string SchedNumDesc
        {
            get
            {
                if (ScheduleNumber == null || ScheduleNumber.Length == 0) return Description;
                else return $"{ScheduleNumber}: {Description}";
            }
        }

        public string SchedNumDescUnit
        {
            get
            {
                if (ScheduleNumber == null || ScheduleNumber.Length == 0) return $"{Description} ({Unit})";
                else return $"{ScheduleNumber}: {Description} ({Unit})";
            }
        }
        public string SchedNumDescEff
        {
            get
            {
                if (IsSummaryLine) return $"Total: {SchedNumDesc}";
                else return $"{SchedNumDesc}";
            }
        }

        public List<WorkScheduleDto> WorkTypes { get; set; }
        public List<ItpScheduleDto> Itps { get; set; }
        public List<SchedCostCodeDto> Ccs { get; set; }

        public decimal AllocationTotal => Ccs == null ? 0 : Ccs.Sum(x => x.DistPercent ?? 0);
    }
}
