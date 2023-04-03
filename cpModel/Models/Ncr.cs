// <auto-generated>
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Models
{
    public partial class Ncr: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int NcrId { get; set; }
        public int? ProjectId { get; set; }
        public int? NcrNo { get; set; }
        public string Location { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public string CorrectiveAction { get; set; }
        public string PreventativeAction { get; set; }
        public string RootCauseDetail { get; set; }
        public string RootCauseCategory { get; set; }
        public DateTime? DateRaised { get; set; }
        public int? RaisedById { get; set; }
        public int? ActionType { get; set; }
        public string RelatedParties { get; set; }
        public int? Severity { get; set; }
        public int? ThirdPartyAppReqd { get; set; }
        public string Notes { get; set; }
        public int? ApprovalById { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalDetails { get; set; }
        public int? CloseOutById { get; set; }
        public DateTime? CloseOutDate { get; set; }
        public string CloseOutDetails { get; set; }
        public decimal? NcrCost { get; set; }
        public int? ApprovalId { get; set; }
        public DateTime? DatePublished { get; set; }
        public string NcrNumSuffix { get; set; }
        public int? BaseNcrId { get; set; }
        public string RevisionData { get; set; }
        public DateTime? DateRevision { get; set; }
        public int? RevisionById { get; set; }
        public string RevisionRef { get; set; }
        public DateTime? DateActive { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Approval> Approvals_CloseOutNcr { get; set; }
        public virtual ICollection<Approval> Approvals_NcrLink { get; set; }
        public virtual ICollection<ApprovalNcr> ApprovalNcrs { get; set; }
        public virtual ICollection<FsNcr> FsNcrs { get; set; }
        public virtual ICollection<FsSurvey> FsSurveys { get; set; }
        public virtual ICollection<FsTestReq> FsTestReqs { get; set; }
        public virtual ICollection<LotItpDetail> LotItpDetails { get; set; }
        public virtual ICollection<LotQuantity> LotQuantities { get; set; }
        public virtual ICollection<Ncr> NcrRevisions { get; set; }
        public virtual ICollection<NcrCustomRegItem> NcrCustomRegItems { get; set; }
        public virtual ICollection<NcrDocument> NcrDocuments { get; set; }
        public virtual ICollection<NcrLot> NcrLots { get; set; }
        public virtual ICollection<NcrPunchlistItem> NcrPunchlistItems { get; set; }
        public virtual ICollection<PhotoNcr> PhotoNcrs { get; set; }
        public virtual ICollection<ProgressClaimSnapshot> ProgressClaimSnapshots { get; set; }

        public virtual Approval Approval { get; set; }
        public virtual Ncr BaseNcr { get; set; }
        public virtual Project Project { get; set; }
        public virtual User ApprovalBy { get; set; }
        public virtual User CloseOutBy { get; set; }
        public virtual User RaisedBy { get; set; }
        public virtual User RevisionBy { get; set; }

        public Ncr()
        {
            Approvals_CloseOutNcr = new HashSet<Approval>();
            Approvals_NcrLink = new HashSet<Approval>();
            ApprovalNcrs = new HashSet<ApprovalNcr>();
            FsNcrs = new HashSet<FsNcr>();
            FsSurveys = new HashSet<FsSurvey>();
            FsTestReqs = new HashSet<FsTestReq>();
            LotItpDetails = new HashSet<LotItpDetail>();
            LotQuantities = new HashSet<LotQuantity>();
            NcrRevisions = new HashSet<Ncr>();
            NcrCustomRegItems = new HashSet<NcrCustomRegItem>();
            NcrDocuments = new HashSet<NcrDocument>();
            NcrLots = new HashSet<NcrLot>();
            NcrPunchlistItems = new HashSet<NcrPunchlistItem>();
            PhotoNcrs = new HashSet<PhotoNcr>();
            ProgressClaimSnapshots = new HashSet<ProgressClaimSnapshot>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

