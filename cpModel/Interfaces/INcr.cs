using System;

namespace cpModel.Interfaces
{
    public interface INcr
    {
        int NcrId { get; set; }
        int? NcrNo { get; set; }
        string Location { get; set; }
        string Description { get; set; }
        string CorrectiveAction { get; set; }
        string PreventativeAction { get; set; }
        string RootCauseDetail { get; set; }
        string RootCauseCategory { get; set; }
        DateTime? DateRaised { get; set; }
        int? RaisedById { get; set; }
        int? ActionType { get; set; }
        string RelatedParties { get; set; }
        int? Severity { get; set; }
        int? ThirdPartyAppReqd { get; set; }
        string Notes { get; set; }
        int? ApprovalById { get; set; }
        DateTime? ApprovalDate { get; set; }
        string ApprovalDetails { get; set; }
        int? CloseOutById { get; set; }
        DateTime? CloseOutDate { get; set; }
        string CloseOutDetails { get; set; }
        decimal? NcrCost { get; set; }
        int? ApprovalId { get; set; }
        DateTime? DatePublished { get; set; }
    }
}
