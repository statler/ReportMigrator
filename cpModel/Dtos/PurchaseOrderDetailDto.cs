using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class PurchaseOrderDetailDto : IEditableObject, ILockableEntity, IOrderable
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<PurchaseOrderDetailDto> _editableImplementation = new EditableModelHelper<PurchaseOrderDetailDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int PoDetailId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal? ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public bool? IsRateOnly { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public string Notes { get; set; }
        public decimal? GstRate { get; set; }
        public int? ResType { get; set; }
        public int? CostCodeId { get; set; }

        public decimal? QtyReceipted { get; set; }
        public decimal? QtyRemaining => (Qty ?? 0) - (QtyReceipted ?? 0);

        public ResourceDto SelectedResource { get; set; }

        public decimal? Total
        {
            get
            {
                if (Rate == null) return null;
                return Math.Round(Rate.Value * (Qty ?? 0), 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal? TotalReceipted
        {
            get
            {
                if (Rate == null) return null;
                return Math.Round(Rate.Value * (QtyReceipted ?? 0), 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal? TotalRemaining => (Total ?? 0) - (TotalReceipted ?? 0);

        public decimal? DisplayTotal
        {
            get
            {
                if ((IsRateOnly ?? false) || Rate == null || Qty == null) return null;
                else return Math.Round(Rate.Value * (Qty ?? 0), 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal? DisplayTotalGST
        {
            get
            {
                if ((IsRateOnly ?? false) || Rate == null || Qty == null || GstRate == null) return null;
                else return Math.Round(Rate.Value * (Qty ?? 0) * (GstRate ?? 0), 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal? DisplayTotalInclGST
        {
            get
            {
                if ((IsRateOnly ?? false) || Rate == null || Qty == null || GstRate == null) return null;
                else return Math.Round(Rate.Value * (Qty ?? 0) * (1M + (GstRate ?? 0)), 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal? DisplayQty
        {
            get
            {
                if ((IsRateOnly ?? false)) return null;
                else return Qty;
            }
        }

        public string ItemDescriptionPlainText
        {
            get
            {
                string plainText = ItemDescription.GetPlainTextFromHTML();
                return plainText == null ? "" : plainText.Trim();
            }
        }

        public string ItemDescriptionPlainTextShort
        {
            get
            {
                string s = ItemDescriptionPlainText;
                int stringLength = Math.Min(100, s.Length);
                return ItemDescriptionPlainText.Substring(0, stringLength);
            }
        }

        public string ItemDescriptionPlainTextForResource
        {
            get
            {
                string s = ItemDescriptionPlainText;
                int stringLength = Math.Min(500, s.Length);
                return ItemDescriptionPlainText.Substring(0, stringLength);
            }
        }

        public decimal? TotalExGST
        {
            get
            {
                if (Rate == null) return null;
                return Math.Round(Rate.Value * (Qty ?? 0), 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal? TotalIncGST => TotalExGST == null ? null : TotalExGST * (1 + (GstRate ?? 0));

        public decimal? OrderId { get => ItemNumber; set => ItemNumber = value; }
    }
}
