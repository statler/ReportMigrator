using System;

namespace cpModel.Dtos
{
    public partial class ProgressClaimSnapshotDto
    {

        public int ProgressClaimSnapshotId { get; set; }
        public int? ProgressClaimVersionId { get; set; }
        public int? LotQtyId { get; set; }
        public int? LotId { get; set; }
        public int? ScheduleId { get; set; }
        public string Description { get; set; }
        public decimal? Qty { get; set; }
        public decimal? ReducedPayment { get; set; }
        public decimal? PercComp { get; set; }
        public DateTime? AdjDate { get; set; }
        public bool? NonClaimable { get; set; }
        public int? Status { get; set; }

        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string ScheduleNumber { get; set; }
        public string ScheduleDescription { get; set; }
        public string Unit { get; set; }

        public decimal EffQty
        {
            get
            {
                if (NonClaimable ?? false)
                {
                    return 0;
                }
                decimal fEffQty = (Qty ?? 0m) * (ReducedPayment ?? 1m);
                if (Status == 1)
                {
                    fEffQty *= (PercComp ?? 0m);
                    return Math.Round(fEffQty, 3, MidpointRounding.AwayFromZero);
                }
                else return fEffQty;
            }
        }

        public string StatusText
        {
            get
            {
                if (Status == 6) return "Floating";
                else if (Status == 3) return "Conformed";
                else if (Status == 2) return "Guaranteed";
                else if (Status == 1) return "Open";
                else return "None";
            }
        }



        public string EffectiveDescription
        {
            get
            {
                if (LotId == null) return Description;
                else if (string.IsNullOrWhiteSpace(Description)) return LotNumber;
                else return LotNumber + " - " + Description;
            }
        }

        public string EffectiveLongDescription
        {
            get
            {
                if (LotId == null) return Description;
                string LongDescription = LotNumber + " - " + LotDescription;
                if (!string.IsNullOrWhiteSpace(Description)) LongDescription += ("\r\n" + Description);
                return LongDescription;
            }
        }
    }
}
