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
    public partial class ProgressClaimVersion: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ProgressClaimVersionId { get; set; }
        public int? ProjectId { get; set; }
        public int? ReportPeriodId { get; set; }
        public DateTime? CutoffDate { get; set; }
        public int? VersionIx { get; set; }
        public bool? IsActive { get; set; }
        public string VersionDescription { get; set; }
        public bool? InclOpen { get; set; }
        public bool? InclGuar { get; set; }
        public bool? InclConf { get; set; }
        public bool? InclFloating { get; set; }
        public bool? InclNotAgreed { get; set; }
        public int? PreviousReportPeriodId { get; set; }
        public decimal? PaidThisClaim { get; set; }
        public decimal? Retention { get; set; }
        public decimal? Security { get; set; }
        public DateTime? ApprovedCompletionDate { get; set; }
        public DateTime? ForecastCompletionDate { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DateCertified { get; set; }
        public DateTime? DatePublished { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<FsPClaimDetail> FsPClaimDetails { get; set; }
        public virtual ICollection<ProgressClaimDetail> ProgressClaimDetails { get; set; }
        public virtual ICollection<ProgressClaimReview> ProgressClaimReviews { get; set; }
        public virtual ICollection<ProgressClaimSnapshot> ProgressClaimSnapshots { get; set; }
        public virtual ICollection<ProgressClaimVersionEmail> ProgressClaimVersionEmails { get; set; }

        public virtual Project Project { get; set; }
        public virtual ReportPeriod PreviousReportPeriod { get; set; }
        public virtual ReportPeriod ReportPeriodObject { get; set; }

        public ProgressClaimVersion()
        {
            FsPClaimDetails = new HashSet<FsPClaimDetail>();
            ProgressClaimDetails = new HashSet<ProgressClaimDetail>();
            ProgressClaimReviews = new HashSet<ProgressClaimReview>();
            ProgressClaimSnapshots = new HashSet<ProgressClaimSnapshot>();
            ProgressClaimVersionEmails = new HashSet<ProgressClaimVersionEmail>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

