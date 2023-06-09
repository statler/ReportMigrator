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
    public partial class ForecastCostEstimate: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ForecastCostEstimateId { get; set; }
        public int? ForecastDetailId { get; set; }
        public decimal? ItemOrder { get; set; }
        public string Description { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? Total { get; set; }
        public string Comment { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual ForecastDetail ForecastDetail { get; set; }

        public ForecastCostEstimate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

