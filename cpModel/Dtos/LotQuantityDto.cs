using System;
using cpModel.Enums;

namespace cpModel.Dtos
{
    public class LotQuantityDto : LotQuantityWithConfDto
    {
        public int? NcrId { get; set; }
        public bool? NonClaimable { get; set; }
        public bool? Preliminary { get; set; }
        public decimal? ReducedPayment { get; set; }
        public string Comments { get; set; }
        public int? ApprovedById { get; set; }
        public int? Status { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ApprovalComment { get; set; }
        public decimal? EffectiveQty
        {
            get
            {
                int ncFactor = (NonClaimable ?? false) ? 0 : 1;
                return (Qty ?? 0) * ncFactor * (ReducedPayment ?? 1) * EffectivePercComp;
            }
        }
        public DateTime? LotAdjDate { get; set; }
        public decimal? DjcRate { get; set; }
        public decimal? SellRate { get; set; }
        public string ApprovedByName { get; set; }

        public decimal? EffectiveValue => EffectiveQty * SellRate;
        public decimal Value { get; set; }

        public LotQtyStatusEnum? StatusName => (LotQtyStatusEnum?)Status;


    }
}
