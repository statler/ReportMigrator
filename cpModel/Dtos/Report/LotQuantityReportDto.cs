using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class LotQuantityReportDto
    {
        public int QuantityId { get; set; }
        public int? LotId { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public decimal? PercComp { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

        public decimal? EffectivePercComp { get; set; }

        public int? ScheduleId { get; set; }
        public decimal? ScheduleOrderId { get; set; }
        public string ScheduleNo { get; set; }
        public string ScheduleDescription { get; set; }
        public decimal? ScheduleSellRate { get; set; }
        public string ScheduleNoAndDesc
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ScheduleNo)) return ScheduleDescription;
                else return ScheduleNo + ": " + ScheduleDescription;
            }
        }

        public string ScheduleNoDescAndUnit => $"{ScheduleNoAndDesc} {Unit}";

        public bool? NonClaimable { get; set; }
        public decimal? ReducedPayment { get; set; }
        public decimal? EffectiveQty
        {
            get
            {
                int ncFactor = (NonClaimable ?? false) ? 0 : 1;
                return (Qty ?? 0) * ncFactor * (ReducedPayment ?? 1) * EffectivePercComp;
            }
        }


        public string EffectiveLongDescription
        {
            get
            {
                if (LotId == null) return Description;
                string LongDescription = LotNumber + ": " + LotDescription;
                if (!string.IsNullOrWhiteSpace(Description)) LongDescription += ("\r\n" + Description);
                return LongDescription;
            }
        }
        public DateTime? ApprovalDate { get; set; }

        public string EffectiveLongDescriptionWithFactors
        {
            get
            {
                List<string> lstAdjustments = new List<string>();
                if (EffectivePercComp != 1) lstAdjustments.Add($"{EffectivePercComp:#,##0.0##%}");
                if (ReducedPayment != 1) lstAdjustments.Add($"RPF {ReducedPayment:#,##0.0##%}");
                if (NonClaimable ?? false) lstAdjustments.Add($"Non Claimable");
                if (lstAdjustments.Count == 0) return EffectiveLongDescription;
                else return $"{EffectiveLongDescription} ({string.Join(" | ", lstAdjustments)})";
            }
        }

        public decimal EffectiveValue
        {
            get
            {
                if (NonClaimable ?? false)
                    return 0;
                else return (ScheduleSellRate == null) ? 0M : (EffectiveQty ?? 0) * Convert.ToDecimal(ScheduleSellRate.Value);
            }
        }

        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateRejected { get; set; }

        public string Status
        {
            get
            {
                if (DateRejected != null) return Models.Lot.RejectedString;
                if ((DateConf != null) && (DateConf != DateTime.MinValue)) return "Conformed";
                else if ((DateGuar != null) && (DateGuar != DateTime.MinValue)) return "Guaranteed";
                else return "Open";
            }
        }
    }
}
