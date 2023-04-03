using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class IncidentBaseDto : IncidentListDto,  ILockableEntity
    {
        public int? ProjectId { get; set; }
        public decimal? LtiHours { get; set; }
        public decimal? EstCost { get; set; }
        public string Location { get; set; }
        public int? ReportedById { get; set; }
        public string ReportedByName { get; set; }
        public int? ReportedToId { get; set; }
        public string ReportedToName { get; set; }
        public string Status { get; set; }
        public string IncidentTypeName { get; set; }
        public bool? ReportReqdFromSubbie { get; set; }
        public DateTime? DateHseAdvised { get; set; }
        public string CauseIncidentHtml { get; set; }
        public string WeatherConditions { get; set; }
        public bool? CoveredBySwms { get; set; }
        public string SwmsReference { get; set; }
        public string ActionsHtml { get; set; }
        public string ActionsPreventReoccurrenceHtml { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedCommentsHtml { get; set; }
        public int? CloseoutById { get; set; }
        public DateTime? CloseOutDate { get; set; }
        public string CloseOutCommentsHtml { get; set; }
        public int? SiteDiaryId { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }


    }
}
