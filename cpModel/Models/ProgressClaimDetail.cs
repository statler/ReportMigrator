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
    public partial class ProgressClaimDetail: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ProgressClaimDetailId { get; set; }
        public int? ProgressClaimVersionId { get; set; }
        public int? ReportPeriodId { get; set; }
        public int? ScheduleId { get; set; }
        public decimal? QtyPreviousCertified { get; set; }
        public decimal? DjcRatePrev { get; set; }
        public decimal? SellRatePrev { get; set; }
        public decimal? QtyCertified { get; set; }
        public decimal? SellRateCert { get; set; }
        public decimal? QtyOverUnder { get; set; }
        public decimal? QtyClaimed { get; set; }
        public decimal? DjcRate { get; set; }
        public decimal? SellRate { get; set; }
        public decimal? QtyAtCompl { get; set; }
        public decimal? DjcRateAtComp { get; set; }
        public decimal? SellRateAtComp { get; set; }
        public decimal? RiskOpp { get; set; }
        public bool? IsOverhead { get; set; }
        public bool? IsVariableRate { get; set; }
        public decimal? OrderId { get; set; }
        public int? ParentId { get; set; }
        public string ScheduleNumber { get; set; }
        public string Description { get; set; }
        public decimal? QtyScheduled { get; set; }
        public string Unit { get; set; }
        public bool? IsTotalled { get; set; }
        public string Notes { get; set; }
        public bool? IsVrn { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<FsPClaimDetail> FsPClaimDetails { get; set; }
        public virtual ICollection<ProgressClaimReviewQuantity> ProgressClaimReviewQuantities { get; set; }

        public virtual ProgressClaimVersion ProgressClaimVersion { get; set; }
        public virtual ReportPeriod ReportPeriod { get; set; }
        public virtual ScheduleItem ScheduleItem { get; set; }

        public ProgressClaimDetail()
        {
            FsPClaimDetails = new HashSet<FsPClaimDetail>();
            ProgressClaimReviewQuantities = new HashSet<ProgressClaimReviewQuantity>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

