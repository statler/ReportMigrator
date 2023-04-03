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
    public partial class InvoiceOrder: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int InvoiceOrderId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal? Amount { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public InvoiceOrder()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

