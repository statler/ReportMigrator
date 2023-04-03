using cpModel.Enums;
using System;

namespace cpModel.Dtos.Report
{
    public class VrnWaypointReportDto
    {
        public int VrnWaypointId { get; set; }
        public int? VariationId { get; set; }
        public int? VrnStatusId { get; set; }
        public DateTime? WaypointDate { get; set; }
        public string Description { get; set; }
        public string StatusName => ((VrnStatusEnum)VrnStatusId).ToString();
    }
}
