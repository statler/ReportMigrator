
using cpModel.Enums;

namespace cpModel.Dtos
{
    public partial class ApprovalBasicLinkDto
    {
        public int ApprovalId { get; set; }
        public int? ApprovalNo { get; set; }
        public int? ApprovalCategoryId { get; set; }
        public int? LinkId
        {
            get
            {
                var category = (ApprovalCategoryEnum)ApprovalCategoryId;
                switch (category)
                {
                    case ApprovalCategoryEnum.Hold_Point:
                    case ApprovalCategoryEnum.Witness_Point:
                    case ApprovalCategoryEnum.Check_Item:
                        return LotItpDetailLinkId;
                    case ApprovalCategoryEnum.NCR:
                        return NcrLinkId;
                    case ApprovalCategoryEnum.Purchase_Order:
                        return PurchaseOrderLinkId;
                    case ApprovalCategoryEnum.Independent:
                        return null;
                }
                return null;
            }
        }
        public int? NcrLinkId { get; set; }
        public int? LotItpDetailLinkId { get; set; }
        public int? PurchaseOrderLinkId { get; set; }
    }

}
// </auto-generated>
