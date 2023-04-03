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
    public partial class ReceiptDetail: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ReceiptDetailId { get; set; }
        public int? ReceiptId { get; set; }
        public int? PoDetailId { get; set; }
        public decimal? Qty { get; set; }
        public string Notes { get; set; }
        public int? CostCodeId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<DayCost> DayCosts { get; set; }

        public virtual CostCode CostCode { get; set; }
        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }
        public virtual Receipt Receipt { get; set; }

        public ReceiptDetail()
        {
            DayCosts = new HashSet<DayCost>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

