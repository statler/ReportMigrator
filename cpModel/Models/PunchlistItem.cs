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
    public partial class PunchlistItem: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int PunchlistItemId { get; set; }
        public int? PunchlistId { get; set; }
        public decimal? OrderId { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? PersonResponsibleId { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Notes { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? CheckById { get; set; }
        public DateTime? VerifyDate { get; set; }
        public int? VerifyById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovalComments { get; set; }
        public int? ApprovalId { get; set; }
        public bool? CheckReqd { get; set; }
        public bool? VerifyReqd { get; set; }
        public bool? ApprovalReqd { get; set; }
        public bool? IsInternal { get; set; }
        public string ItemNo { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<ApprovalPunchlistItem> ApprovalPunchlistItems { get; set; }
        public virtual ICollection<FsPunchlistItem> FsPunchlistItems { get; set; }
        public virtual ICollection<LotPunchlistItem> LotPunchlistItems { get; set; }
        public virtual ICollection<NcrPunchlistItem> NcrPunchlistItems { get; set; }
        public virtual ICollection<PhotoPunchListItem> PhotoPunchListItems { get; set; }
        public virtual ICollection<PunchlistItemPoint> PunchlistItemPoints { get; set; }

        public virtual Approval Approval { get; set; }
        public virtual Punchlist Punchlist { get; set; }
        public virtual User ApprovedBy { get; set; }
        public virtual User CheckBy { get; set; }
        public virtual User PersonResponsible { get; set; }
        public virtual User VerifyBy { get; set; }

        public PunchlistItem()
        {
            Approvals = new HashSet<Approval>();
            ApprovalPunchlistItems = new HashSet<ApprovalPunchlistItem>();
            FsPunchlistItems = new HashSet<FsPunchlistItem>();
            LotPunchlistItems = new HashSet<LotPunchlistItem>();
            NcrPunchlistItems = new HashSet<NcrPunchlistItem>();
            PhotoPunchListItems = new HashSet<PhotoPunchListItem>();
            PunchlistItemPoints = new HashSet<PunchlistItemPoint>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
