using System;
using System.Collections.Generic;

namespace cpModel.Dtos
{
    public partial class VariationDto : VariationListDto
    {

        public string ClientRef { get; set; }
        public int? RaisedById { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateIdentified { get; set; }
        public DateTime? DateNotified { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public decimal? EotDays { get; set; }
        public decimal? EotDaysApproved { get; set; }
        public decimal? QtySubmitted { get; set; }
        public decimal? QtyApproved { get; set; }
        public string Unit { get; set; }
        public decimal? DjcTotalSubmitted { get; set; }
        public decimal? DjcTotalApproved { get; set; }
        public decimal? DefaultMargin { get; set; }
        public decimal? VisibleMargin { get; set; }
        public string Notes { get; set; }
        public string Detail { get; set; }
        public decimal DJCTotalEstimate { get; set; }
        public ICollection<VrnWaypointDto> VrnWaypoints { get; set; }
        public DateTime? DateIncludeInClaim { get; set; }
        public DateTime? DateUseApprovedValue { get; set; }
    }

}
