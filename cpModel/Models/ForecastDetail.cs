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
    public partial class ForecastDetail: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ForecastDetailId { get; set; }
        public int? ForecastVersionId { get; set; }
        public int? QtdMethodId { get; set; }
        public int? ForecastMethodId { get; set; }
        public int? CostCodeId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsSplitDate { get; set; }
        public bool? IsCostSeparate { get; set; }
        public decimal? Qtd { get; set; }
        public decimal? QtdCalc { get; set; }
        public decimal? Btd { get; set; }
        public decimal? Ctd { get; set; }
        public decimal? RevTd { get; set; }
        public decimal? Ctc { get; set; }
        public decimal? Qac { get; set; }
        public decimal? QacCalc { get; set; }
        public decimal? Bac { get; set; }
        public decimal? RevAc { get; set; }
        public decimal? WinLossAdj { get; set; }
        public decimal? BacOrig { get; set; }
        public decimal? RevAcOrig { get; set; }
        public bool? IsQtdManual { get; set; }
        public bool? IsBtdManual { get; set; }
        public bool? IsCtdManual { get; set; }
        public bool? IsQacManual { get; set; }
        public bool? IsBacManual { get; set; }
        public bool? UseQtySum { get; set; }
        public decimal? EstimateQty { get; set; }
        public bool? FactorEstimate { get; set; }
        public decimal? EstimateAppliedQty { get; set; }
        public string Comments { get; set; }
        public decimal? CacFixed { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ForecastCashflow> ForecastCashflows { get; set; }
        public virtual ICollection<ForecastCostEstimate> ForecastCostEstimates { get; set; }

        public virtual CostCode CostCode { get; set; }
        public virtual ForecastVersion ForecastVersion { get; set; }

        public ForecastDetail()
        {
            ForecastCashflows = new HashSet<ForecastCashflow>();
            ForecastCostEstimates = new HashSet<ForecastCostEstimate>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

