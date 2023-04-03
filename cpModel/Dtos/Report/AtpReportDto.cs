using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{

    public class AtpReportDto
    {
        public int AtpId { get; set; }
        public int? AtpNo { get; set; }
        public string Description { get; set; }
        public int? ProjectId { get; set; }
        public int? RequestedById { get; set; }
        public int? SentToId { get; set; }
        public DateTime? DateRespRequired { get; set; }
        public DateTime? Datesub { get; set; }
        public DateTime? Timesub { get; set; }
        public List<AtpLotReportDto> Lots { get; set; }
        public string RequestedByName { get; set; }
        public string RequestedByPosition { get; set; }
        public string SentToName { get; set; }
        public string SentToPosition { get; set; }
    }

}
