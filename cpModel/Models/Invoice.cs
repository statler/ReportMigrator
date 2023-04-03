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
    public partial class Invoice: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int InvoiceId { get; set; }
        public int? ReportPeriodId { get; set; }
        public int? SupplierId { get; set; }
        public string InvoiceRef { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDesc { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Gst { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateAuthorized { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal? AmountPaid { get; set; }
        public string Notes { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<DayCost> DayCosts { get; set; }
        public virtual ICollection<FsInvoice> FsInvoices { get; set; }
        public virtual ICollection<InvoiceCustomRegItem> InvoiceCustomRegItems { get; set; }
        public virtual ICollection<InvoiceDispute> InvoiceDisputes { get; set; }
        public virtual ICollection<InvoiceOrder> InvoiceOrders { get; set; }
        public virtual ICollection<InvoiceRetention> InvoiceRetentions { get; set; }

        public virtual Project Project { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual ReportPeriod ReportPeriod { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }

        public Invoice()
        {
            DayCosts = new HashSet<DayCost>();
            FsInvoices = new HashSet<FsInvoice>();
            InvoiceCustomRegItems = new HashSet<InvoiceCustomRegItem>();
            InvoiceDisputes = new HashSet<InvoiceDispute>();
            InvoiceOrders = new HashSet<InvoiceOrder>();
            InvoiceRetentions = new HashSet<InvoiceRetention>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

