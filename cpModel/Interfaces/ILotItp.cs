using System;

namespace cpModel.Models
{
    public interface ILotItp
    {
        int LotItpId { get; set; }
        int? LotId { get; set; }
        int? ItpId { get; set; }
        int? RaisedById { get; set; }
        string Description { get; set; }
        decimal? LotQuantity { get; set; }
        string Unit { get; set; }
        int? ApprovedById { get; set; }
        DateTime? DateApproved { get; set; }
        string ApprovalComments { get; set; }
        int? CheckedById { get; set; }
        DateTime? DateChecked { get; set; }
        int? VerifiedById { get; set; }
        DateTime? DateVerified { get; set; }
        decimal? LotLength { get; set; }
        decimal? LotArea { get; set; }
        decimal? LotVolume { get; set; }
        DateTime? RevisionDate { get; set; }
        int? RevisionId { get; set; }
        DateTime? ChecklistDate { get; set; }
        string SourceItpNo { get; set; }
        string SourceQvcNo { get; set; }

    }
}
// </auto-generated>


