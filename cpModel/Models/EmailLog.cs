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
    public partial class EmailLog: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public int? ProjectId { get; set; }
        public string EmailTo { get; set; }
        public string EmailCc { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime? DateEmailed { get; set; }
        public string AttachmentString { get; set; }
        public string EmailToIdList { get; set; }
        public string EmailToCcList { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ApprovalEmail> ApprovalEmails { get; set; }
        public virtual ICollection<CnEmail> CnEmails { get; set; }
        public virtual ICollection<FsEmail> FsEmails { get; set; }
        public virtual ICollection<NotificationEmail> NotificationEmails { get; set; }
        public virtual ICollection<PoEmail> PoEmails { get; set; }
        public virtual ICollection<ProgressClaimVersionEmail> ProgressClaimVersionEmails { get; set; }
        public virtual ICollection<SurveyEmail> SurveyEmails { get; set; }
        public virtual ICollection<TestReqEmail> TestReqEmails { get; set; }
        public virtual ICollection<TransmittalEmail> TransmittalEmails { get; set; }

        public virtual Project Project { get; set; }

        public EmailLog()
        {
            ApprovalEmails = new HashSet<ApprovalEmail>();
            CnEmails = new HashSet<CnEmail>();
            FsEmails = new HashSet<FsEmail>();
            NotificationEmails = new HashSet<NotificationEmail>();
            PoEmails = new HashSet<PoEmail>();
            ProgressClaimVersionEmails = new HashSet<ProgressClaimVersionEmail>();
            SurveyEmails = new HashSet<SurveyEmail>();
            TestReqEmails = new HashSet<TestReqEmail>();
            TransmittalEmails = new HashSet<TransmittalEmail>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

