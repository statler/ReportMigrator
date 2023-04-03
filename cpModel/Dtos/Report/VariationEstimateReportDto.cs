using System;

namespace cpModel.Dtos.Report
{
    public class VariationEstimateReportDto
    {
        public int VariationEstimateId { get; set; }
        public int? VariationId { get; set; }
        public decimal? ItemOrder { get; set; }
        public string Description { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? DjcTotal { get; set; }
        public decimal? SellTotal { get; set; }
        public decimal? VisibleMargin { get; set; }
        public string Comment { get; set; }

        public decimal DJCRate
        {
            get
            {
                if (Qty == 0) return 0;
                return Math.Round((DjcTotal ?? 0) / (Qty ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                DjcTotal = value * (Qty ?? 0);
            }
        }

        public decimal VisibleSellRate
        {
            get
            {
                if (Qty == 0) return 0;
                return Math.Round(VisibleTotal / (Qty ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                VisibleTotal = value * (Qty ?? 0);
            }
        }

        public decimal EstQty
        {
            get
            {
                return (Qty ?? 0);
            }
            set
            {
                SellTotal = value * (SellTotal ?? 0);
                DjcTotal = value * (DjcTotal ?? 0);
                Qty = value;
            }
        }

        public decimal SellRate
        {
            get
            {
                if ((Qty ?? 0) == 0) return 0;
                return Math.Round((SellTotal ?? 0) / (Qty ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                SellTotal = value * (Qty ?? 0);
            }
        }

        public decimal VisibleTotal
        {
            get
            {
                if ((1 + VisibleMargin) == 0) return 0;
                return Math.Round((SellTotal ?? 0) / (1 + (VisibleMargin ?? 0)), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                SellTotal = value * (1 + VisibleMargin);
            }
        }

        public decimal DJCMarkup
        {
            get
            {
                if ((DjcTotal ?? 0) == 0) return 0;
                return Math.Round(((SellTotal ?? 0) / (DjcTotal ?? 0)) - 1, 4, MidpointRounding.AwayFromZero);
            }
            set
            {
                SellTotal = (DjcTotal ?? 0) * (1 + value);
            }
        }

        public bool isHeading
        {
            get
            {
                return (Qty ?? 0) == 0 && (SellTotal ?? 0) == 0;
            }
        }
    }
}
