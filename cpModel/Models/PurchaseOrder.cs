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
    public partial class PurchaseOrder: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int PurchaseOrderId { get; set; }
        public int? PoIndex { get; set; }
        public string PoNumber { get; set; }
        public DateTime? PoDate { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierContact { get; set; }
        public DateTime? DateReqd { get; set; }
        public int? ProjectId { get; set; }
        public int? RaisedById { get; set; }
        public int? PoContactId { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovalComments { get; set; }
        public bool? IsComplete { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingEntity { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentTerms { get; set; }
        public string Notes { get; set; }
        public DateTime? SupplierConfirmationDate { get; set; }
        public int? SupplierConfirmationById { get; set; }
        public string SupplierConfirmationNotes { get; set; }
        public decimal? PoBudget { get; set; }
        public string Comments { get; set; }
        public int? ApprovalId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<FsPurchaseOrder> FsPurchaseOrders { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<InvoiceOrder> InvoiceOrders { get; set; }
        public virtual ICollection<PoEmail> PoEmails { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual Approval Approval { get; set; }
        public virtual Project Project { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User ApprovedBy { get; set; }
        public virtual User PoContact { get; set; }
        public virtual User RaisedBy { get; set; }
        public virtual User SupplierConfirmationBy { get; set; }

        public PurchaseOrder()
        {
            Approvals = new HashSet<Approval>();
            FsPurchaseOrders = new HashSet<FsPurchaseOrder>();
            Invoices = new HashSet<Invoice>();
            InvoiceOrders = new HashSet<InvoiceOrder>();
            PoEmails = new HashSet<PoEmail>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            Receipts = new HashSet<Receipt>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
