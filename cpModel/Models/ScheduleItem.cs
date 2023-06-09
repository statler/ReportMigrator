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
    public partial class ScheduleItem: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ScheduleId { get; set; }
        public int? ProjectId { get; set; }
        public decimal? OrderId { get; set; }
        public int? ParentId { get; set; }
        public string ScheduleGroup { get; set; }
        public string ScheduleNumber { get; set; }
        public string Description { get; set; }
        public decimal? QtyForecast { get; set; }
        public decimal? QtyScheduled { get; set; }
        public string Unit { get; set; }
        public decimal? DjcRate { get; set; }
        public decimal? SellRate { get; set; }
        public bool? IsTotalled { get; set; }
        public string Notes { get; set; }
        public bool? IsVrn { get; set; }
        public bool? Disable { get; set; }
        public bool? IsOverhead { get; set; }
        public bool? IsVariableRate { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ItpScheduleItem> ItpScheduleItems { get; set; }
        public virtual ICollection<LotQuantity> LotQuantities { get; set; }
        public virtual ICollection<ProgressClaimDetail> ProgressClaimDetails { get; set; }
        public virtual ICollection<ProgressClaimSnapshot> ProgressClaimSnapshots { get; set; }
        public virtual ICollection<SchedCostCode> SchedCostCodes { get; set; }
        public virtual ICollection<TestRequestTest> TestRequestTests { get; set; }
        public virtual ICollection<TestSchedule> TestSchedules { get; set; }
        public virtual ICollection<VariationSchedule> VariationSchedules { get; set; }
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }

        public virtual Project Project { get; set; }

        public ScheduleItem()
        {
            ItpScheduleItems = new HashSet<ItpScheduleItem>();
            LotQuantities = new HashSet<LotQuantity>();
            ProgressClaimDetails = new HashSet<ProgressClaimDetail>();
            ProgressClaimSnapshots = new HashSet<ProgressClaimSnapshot>();
            SchedCostCodes = new HashSet<SchedCostCode>();
            TestRequestTests = new HashSet<TestRequestTest>();
            TestSchedules = new HashSet<TestSchedule>();
            VariationSchedules = new HashSet<VariationSchedule>();
            WorkSchedules = new HashSet<WorkSchedule>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

