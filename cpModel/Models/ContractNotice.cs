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
    public partial class ContractNotice: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ConId { get; set; }
        public int? ProjectId { get; set; }
        public int? ConTempId { get; set; }
        public string ConTemplateRef { get; set; }
        public int? ConTypeIx { get; set; }
        public string ConRef { get; set; }
        public DateTime? ConDate { get; set; }
        public int? RequestById { get; set; }
        public int? RequestOnBehalfId { get; set; }
        public DateTime? DateResponseRequired { get; set; }
        public int? RequestToId { get; set; }
        public string ConSubjectHtml { get; set; }
        public string SubjectHtmlTemp { get; set; }
        public string ConHtml { get; set; }
        public bool? ResponseExpected { get; set; }
        public DateTime? DateLocked { get; set; }
        public int? ApprovalStatus { get; set; }
        public string CloseOutHtml { get; set; }
        public DateTime? CloseOutDate { get; set; }
        public int? CloseOutById { get; set; }
        public DateTime? DateSent { get; set; }
        public int? ApproveToSendById { get; set; }
        public DateTime? ApproveToSendDate { get; set; }
        public string Notes { get; set; }
        public int? Priority { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<CnApproval> CnApprovals { get; set; }
        public virtual ICollection<CnControlledDoc> CnControlledDocs { get; set; }
        public virtual ICollection<CnCustomRegItem> CnCustomRegItems { get; set; }
        public virtual ICollection<CnEmail> CnEmails { get; set; }
        public virtual ICollection<CnIncident> CnIncidents { get; set; }
        public virtual ICollection<CnInstruction> CnInstructions { get; set; }
        public virtual ICollection<CnItp> CnItps { get; set; }
        public virtual ICollection<CnLot> CnLots { get; set; }
        public virtual ICollection<CnNotice> CnNotices_CnId1 { get; set; }
        public virtual ICollection<CnNotice> CnNotices_CnId2 { get; set; }
        public virtual ICollection<CnPhoto> CnPhotos { get; set; }
        public virtual ICollection<CnResponse> CnResponses { get; set; }
        public virtual ICollection<CnTo> CnTos { get; set; }
        public virtual ICollection<CnVariation> CnVariations { get; set; }
        public virtual ICollection<FsNotice> FsNotices { get; set; }

        public virtual ContractNoticeTemplate ContractNoticeTemplate { get; set; }
        public virtual Project Project { get; set; }
        public virtual User ApproveToSendBy { get; set; }
        public virtual User CloseOutBy { get; set; }
        public virtual User RequestBy { get; set; }
        public virtual User RequestOnBehalf { get; set; }
        public virtual User RequestTo { get; set; }

        public ContractNotice()
        {
            CnApprovals = new HashSet<CnApproval>();
            CnControlledDocs = new HashSet<CnControlledDoc>();
            CnCustomRegItems = new HashSet<CnCustomRegItem>();
            CnEmails = new HashSet<CnEmail>();
            CnIncidents = new HashSet<CnIncident>();
            CnInstructions = new HashSet<CnInstruction>();
            CnItps = new HashSet<CnItp>();
            CnLots = new HashSet<CnLot>();
            CnNotices_CnId1 = new HashSet<CnNotice>();
            CnNotices_CnId2 = new HashSet<CnNotice>();
            CnPhotos = new HashSet<CnPhoto>();
            CnResponses = new HashSet<CnResponse>();
            CnTos = new HashSet<CnTo>();
            CnVariations = new HashSet<CnVariation>();
            FsNotices = new HashSet<FsNotice>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

