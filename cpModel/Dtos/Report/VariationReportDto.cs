
using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public class VariationReportDto
    {
        public int VariationId { get; set; }
        public int? ProjectId { get; set; }
        public string VariationNo { get; set; }
        public string ClientRef { get; set; }
        public string Description { get; set; }
        public int? RaisedById { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateIdentified { get; set; }
        public DateTime? DateNotified { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public decimal? EotDays { get; set; }
        public decimal? EotDaysApproved { get; set; }
        public decimal? QtyEstimated { get; set; }
        public decimal? QtySubmitted { get; set; }
        public decimal? QtyApproved { get; set; }
        public string Unit { get; set; }
        public decimal? DjcTotalSubmitted { get; set; }
        public decimal? DjcTotalApproved { get; set; }
        public decimal? SellTotalSubmitted { get; set; }
        public decimal? SellTotalApproved { get; set; }
        public decimal? DefaultMargin { get; set; }
        public decimal? VisibleMargin { get; set; }
        public string Notes { get; set; }
        public string Detail { get; set; }
        public DateTime? DateIncludeInClaim { get; set; }
        public DateTime? DateUseApprovedValue { get; set; }

        public List<VariationEstimateReportDto> Estimates { get; set; }
        public List<VrnWaypointReportDto> Waypoints { get; set; }
        public List<VariationLotReportDto> Lots { get; set; }
        public List<PhotoVariationReportDto> Photos { get; set; }

        public decimal TotalMarkup
        {
            get
            {
                var djctotal = Estimates.Sum(x => x.DjcTotal ?? 0);
                if (djctotal == 0) return 0;
                var selltotal = Estimates.Sum(x => x.SellTotal ?? 0);
                return (selltotal / djctotal) - 1;
            }
        }

        public string RaisedByName { get; set; }

        public decimal DJCRateSubmitted
        {
            get
            {
                if ((QtySubmitted ?? 0) == 0) return 0;
                return Math.Round((DjcTotalSubmitted ?? 0) / (QtySubmitted ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                if ((QtySubmitted ?? 0) == 0) QtySubmitted = 1;
                DjcTotalSubmitted = value * QtySubmitted;
            }
        }


        public decimal SellRateSubmitted
        {
            get
            {
                if ((QtySubmitted ?? 0) == 0) return 0;
                return Math.Round((SellTotalSubmitted ?? 0) / (QtySubmitted ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                if ((QtySubmitted ?? 0) == 0) QtySubmitted = 1;
                SellTotalSubmitted = value * QtySubmitted;
            }
        }


        public decimal DJCRateApproved
        {
            get
            {
                if ((QtyApproved ?? 0) == 0) return 0;
                return Math.Round((DjcTotalApproved ?? 0) / (QtyApproved ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                if ((QtyApproved ?? 0) == 0) QtyApproved = 1;
                DjcTotalApproved = value * QtyApproved;
            }
        }


        public decimal SellRateApproved
        {
            get
            {
                if ((QtyApproved ?? 0) == 0) return 0;
                return Math.Round((SellTotalApproved ?? 0) / (QtyApproved ?? 0), 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                if ((QtyApproved ?? 0) == 0) QtyApproved = 1;
                SellTotalApproved = value * QtyApproved;
            }
        }



        public int CurrentStatusId { get; set; }
        public string CurrentStatus => ((VrnStatusEnum)CurrentStatusId).ToString();

        public bool HasBuildup { get; set; }

        public DateTime? CurrentStatusDate { get; set; }
        public string CurrentStatusInclDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CurrentStatus)) return "";
                if (CurrentStatusDate == null) return $"{CurrentStatus}";
                else return $"{CurrentStatus} ({CurrentStatusDate.Value:d})";
            }
        }
    }
}
