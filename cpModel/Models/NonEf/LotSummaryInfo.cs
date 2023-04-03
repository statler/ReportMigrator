using AutoMapper;
using AutoMapper.QueryableExtensions;
using cpORM;
using cpModel.Models;
using cpModel.Dtos.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cpModel.Interfaces;

namespace cpModel.Models.NonEf
{
    public class LotSummaryInfo
    {

        private List<LotMonthSummary> summaryTable;

        /// <summary>
        /// Initializes a new instance of the LotSummaryFactory class.
        /// </summary>
        public LotSummaryInfo(List<LotDatesReportDto> lstLots, List<NcrDateReportDto> lstNcrs, List<TestRequestDatesReportDto> lstTrs)
        {
            summaryTable = new List<LotMonthSummary>();
            Summarize(lstLots, lstNcrs, lstTrs);
        }

        public List<LotMonthSummary> SummaryTable
        {
            get { return summaryTable.OrderBy(x => x.Period).ToList(); }
        }

        public void combineSummaryData(LotMonthSummary newSummaryLine)
        {
            LotMonthSummary existingLine = summaryTable.FirstOrDefault(x => x.Period == newSummaryLine.Period);
            if (existingLine == null) summaryTable.Add(newSummaryLine);
            else
            {
                existingLine.TotalLots += newSummaryLine.TotalLots;
                existingLine.LotOpenAtEOM += newSummaryLine.LotOpenAtEOM;
                existingLine.LotGuarAtEOM += newSummaryLine.LotGuarAtEOM;
                existingLine.LotConfAtEOM += newSummaryLine.LotConfAtEOM;
                existingLine.LotsOpened += newSummaryLine.LotsOpened;
                existingLine.LotsGuaranteed += newSummaryLine.LotsGuaranteed;
                existingLine.LotsConformed += newSummaryLine.LotsConformed;
                existingLine.NCROpenAtEOM += newSummaryLine.NCROpenAtEOM;
                existingLine.NCRAppAtEOM += newSummaryLine.NCRAppAtEOM;
                existingLine.NCRClsdAtEOM += newSummaryLine.NCRClsdAtEOM;
                existingLine.NCROpened += newSummaryLine.NCROpened;
                existingLine.NCRsApproved += newSummaryLine.NCRsApproved;
                existingLine.NCRsClosedOut += newSummaryLine.NCRsClosedOut;
                existingLine.TotalNCRs += newSummaryLine.TotalNCRs;
                existingLine.TrOpenAtEOM += newSummaryLine.TrOpenAtEOM;
                existingLine.TrCompleteAtEOM += newSummaryLine.TrCompleteAtEOM;
                existingLine.TrOpened += newSummaryLine.TrOpened;
                existingLine.TrCompleted += newSummaryLine.TrCompleted;
                existingLine.TotalTR += newSummaryLine.TotalTR;
            }
        }

        public class SummaryStat
        {
            public DateTime period { get; set; }
            public int cnt { get; set; }
        }


        private void Summarize(List<LotDatesReportDto> lstLots, List<NcrDateReportDto> lstNcrs, List<TestRequestDatesReportDto> lstTrs)
        {
            summarizeLots(lstLots);
            summarizeNCRs(lstNcrs);
            summarizeTRs(lstTrs);
            SetMinMaxDates();
            BuildLotTable(lstLots);
            BuildNcrTable(lstNcrs);
            BuildTrTable(lstTrs);
        }

        void SetMinMaxDates()
        {
            var dates = _openedInMonth.Concat(_guarInMonth).Concat(_confInMonth)
                .Concat(ncropenedInMonth).Concat(ncrapprovedInMonth).Concat(ncrclosedInMonth)
                .Concat(tropenedInMonth).Concat(trcompletedInMonth)
                .Select(x => x.period);
            _minDate = dates.Min();
            _maxDate = dates.Max();
        }

        DateTime _minDate;
        DateTime _maxDate;
        IEnumerable<SummaryStat> _openedInMonth;
        IEnumerable<SummaryStat> _guarInMonth;
        IEnumerable<SummaryStat> _confInMonth;
        void summarizeLots(List<LotDatesReportDto> lots)
        {
            _openedInMonth = lots.Where(a => a.DateOpen != null).GroupBy(x => new { mnth = x.DateOpen.Value.Month, yr = x.DateOpen.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in _openedInMonth) combineSummaryData(new LotMonthSummary(item.period) { LotsOpened = item.cnt });
            _guarInMonth = lots.Where(a => a.DateGuar != null).GroupBy(x => new { mnth = x.DateGuar.Value.Month, yr = x.DateGuar.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in _guarInMonth) combineSummaryData(new LotMonthSummary(item.period) { LotsGuaranteed = item.cnt });
            _confInMonth = lots.Where(a => a.DateConf != null).GroupBy(x => new { mnth = x.DateConf.Value.Month, yr = x.DateConf.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in _confInMonth) combineSummaryData(new LotMonthSummary(item.period) { LotsConformed = item.cnt });

        }

        private void BuildLotTable(List<LotDatesReportDto> lots)
        {
            //Ensure there is an entry for every month in the range and caculate status at each period

            DateTime iterDate = _minDate;
            //Ensure all dates within lot range are covered
            while (iterDate.Date <= _maxDate.Date)
            {
                int TotalLotsAtDate = 0;
                int[] noEachStatus = new int[3];
                foreach (LotDatesReportDto lot in lots)
                {
                    if (iterDate.Date.Subtract(lot.DateOpen.Value.Date).Days >= 0) TotalLotsAtDate++;
                    LotStatus? statusAtDate = GetStatusAtCutoffDate(lot, iterDate);
                    if (statusAtDate == null || (int)statusAtDate > 3) continue;
                    noEachStatus[(int)statusAtDate - 1]++;
                }
                combineSummaryData(new LotMonthSummary(iterDate) { LotOpenAtEOM = noEachStatus[0], LotGuarAtEOM = noEachStatus[1], LotConfAtEOM = noEachStatus[2], TotalLots = TotalLotsAtDate });
                DateTime incDate = iterDate.AddMonths(1);
                iterDate = new DateTime(incDate.Year, incDate.Month, DateTime.DaysInMonth(incDate.Year, incDate.Month));
            }
        }

        public static LotStatus GetStatus(ILotDates l, bool inclPreOpen = true)
        {
            if (l.DateRejected != null) return LotStatus.Rejected;
            else if (l.DateConf != null) return LotStatus.Conformed;
            else if (l.DateGuar != null) return LotStatus.Guaranteed;
            if (inclPreOpen && l.DateWorkSt == null) return LotStatus.PreOpen;
            else return LotStatus.Open;
        }

        static LotStatus? GetStatusAtCutoffDate(LotDatesReportDto l, DateTime? d)
        {
            if (d == null) return GetStatus(l, false);
            //At the date, was it conformed? If not, was it guaranteed, or open?
            if (l.DateRejected != null && d.Value.Date.Subtract(l.DateRejected.Value.Date).Days >= 0) return LotStatus.Rejected;
            else if (l.DateConf != null && d.Value.Date.Subtract(l.DateConf.Value.Date).Days >= 0) return LotStatus.Conformed;
            else if (l.DateGuar != null && d.Value.Date.Subtract(l.DateGuar.Value.Date).Days >= 0) return LotStatus.Guaranteed;
            else if (l.DateOpen != null && d.Value.Date.Subtract(l.DateOpen.Value.Date).Days >= 0) return LotStatus.Open;
            else return null;
        }

        IEnumerable<SummaryStat> ncropenedInMonth;
        IEnumerable<SummaryStat> ncrapprovedInMonth;
        IEnumerable<SummaryStat> ncrclosedInMonth;
        void summarizeNCRs(List<NcrDateReportDto> ncrs)
        {
            ncropenedInMonth = ncrs.Where(a => a.DateRaised != null).GroupBy(x => new { mnth = x.DateRaised.Value.Month, yr = x.DateRaised.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in ncropenedInMonth) combineSummaryData(new LotMonthSummary(item.period) { NCROpened = item.cnt });
            ncrapprovedInMonth = ncrs.Where(a => a.ApprovalDate != null).GroupBy(x => new { mnth = x.ApprovalDate.Value.Month, yr = x.ApprovalDate.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in ncrapprovedInMonth) combineSummaryData(new LotMonthSummary(item.period) { NCRsApproved = item.cnt });
            ncrclosedInMonth = ncrs.Where(a => a.CloseOutDate != null).GroupBy(x => new { mnth = x.CloseOutDate.Value.Month, yr = x.CloseOutDate.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in ncrclosedInMonth) combineSummaryData(new LotMonthSummary(item.period) { NCRsClosedOut = item.cnt });

        }

        private void BuildNcrTable(List<NcrDateReportDto> ncrs)
        {
            DateTime iterDate = _minDate;
            //Ensure all dates within lot range are covered
            while (iterDate.Date <= _maxDate.Date)
            {
                int TotalNCRsAtDate = 0;
                int[] noEachStatus = new int[3];
                foreach (NcrDateReportDto ncr in ncrs)
                {
                    if (ncr.DateRaised != null && iterDate.Date.Subtract(ncr.DateRaised.Value.Date).Days >= 0) TotalNCRsAtDate++;
                    NCRStatus? statusAtDate = GetStatusAtCutoffDate(ncr, iterDate);
                    if (statusAtDate == null || (int)statusAtDate > 3) continue;
                    noEachStatus[(int)statusAtDate - 1]++;
                }
                combineSummaryData(new LotMonthSummary(iterDate) { NCROpenAtEOM = noEachStatus[0], NCRAppAtEOM = noEachStatus[1], NCRClsdAtEOM = noEachStatus[2], TotalNCRs = TotalNCRsAtDate });
                DateTime incDate = iterDate.AddMonths(1);
                iterDate = new DateTime(incDate.Year, incDate.Month, DateTime.DaysInMonth(incDate.Year, incDate.Month));
            }
        }

        static NCRStatus GetStatus(NcrDateReportDto n)
        {
            if (n.CloseOutDate != null) return NCRStatus.ClosedOut;
            else if (n.ApprovalDate != null) return NCRStatus.Approved;
            else return NCRStatus.Open;
        }

        /// <summary>
        /// Gets the lot status at a particular date. If the date is null, returns the current lot status
        /// If the lot did not exist at that date, returns null
        /// </summary>
        /// <param name="n">The lot to get the status for</param>
        /// <param name="d">The date for the status</param>
        /// <returns>The lot status at the given date (or current lot status for null date)</returns>
        static NCRStatus? GetStatusAtCutoffDate(NcrDateReportDto n, DateTime? d)
        {
            if (d == null) return GetStatus(n);
            //At the date, was it conformed? If not, was it guaranteed, or open?
            if (n.CloseOutDate != null && d.Value.Date.Subtract(n.CloseOutDate.Value.Date).Days >= 0) return NCRStatus.ClosedOut;
            else if (n.ApprovalDate != null && d.Value.Date.Subtract(n.ApprovalDate.Value.Date).Days >= 0) return NCRStatus.Approved;
            else if (n.DateRaised != null && d.Value.Date.Subtract(n.DateRaised.Value.Date).Days >= 0) return NCRStatus.Open;
            else return null;
        }

        IEnumerable<SummaryStat> tropenedInMonth;
        IEnumerable<SummaryStat> trcompletedInMonth;
        void summarizeTRs(List<TestRequestDatesReportDto> trs)
        {
            tropenedInMonth = trs.Where(a => a.DateRequest != null).GroupBy(x => new { mnth = x.DateRequest.Value.Month, yr = x.DateRequest.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in tropenedInMonth) combineSummaryData(new LotMonthSummary(item.period) { TrOpened = item.cnt });
            trcompletedInMonth = trs.Where(a => a.DateTestCompleted != null).GroupBy(x => new { mnth = x.DateTestCompleted.Value.Month, yr = x.DateTestCompleted.Value.Year, count = 1 }).Select(y => new SummaryStat { period = new DateTime(y.Key.yr, y.Key.mnth, DateTime.DaysInMonth(y.Key.yr, y.Key.mnth)), cnt = y.Count() });
            foreach (var item in trcompletedInMonth) combineSummaryData(new LotMonthSummary(item.period) { TrCompleted = item.cnt });

        }

        private void BuildTrTable(List<TestRequestDatesReportDto> trs)
        {
            DateTime iterDate = _minDate;

            while (iterDate.Date <= _maxDate.Date)
            {
                int TotalTRsAtDate = 0;
                int[] noEachStatus = new int[2];
                foreach (TestRequestDatesReportDto tr in trs)
                {
                    if (tr.DateRequest != null && iterDate.Date.Subtract(tr.DateRequest.Value.Date).Days >= 0) TotalTRsAtDate++;
                    TRStatus? statusAtDate = GetStatusAtCutoffDate(tr, iterDate);
                    if (statusAtDate == null || (int)statusAtDate > 2) continue;
                    noEachStatus[(int)statusAtDate - 1]++;
                }

                combineSummaryData(new LotMonthSummary(iterDate) { TrOpenAtEOM = noEachStatus[0], TrCompleteAtEOM = noEachStatus[1], TotalTR = TotalTRsAtDate });
                DateTime incDate = iterDate.AddMonths(1);
                iterDate = new DateTime(incDate.Year, incDate.Month, DateTime.DaysInMonth(incDate.Year, incDate.Month));
            }
        }

        static TRStatus? GetStatusAtCutoffDate(TestRequestDatesReportDto n, DateTime? d)
        {
            if (d == null) return GetStatus(n);
            //At the date, was it conformed? If not, was it guaranteed, or open?
            if (n.DateTestCompleted != null && d.Value.Date.Subtract(n.DateTestCompleted.Value.Date).Days >= 0) return TRStatus.Completed;
            else if (n.DateRequest != null && d.Value.Date.Subtract(n.DateRequest.Value.Date).Days >= 0) return TRStatus.Open;
            else return null;
        }

        static TRStatus GetStatus(TestRequestDatesReportDto n)
        {
            if (n.DateTestCompleted != null) return TRStatus.Completed;
            else return TRStatus.Open;
        }
        //public static List<(int vID, VRNStatusStats? s)> GetStatusAtCutoffDate(int ProjectID, XPCollection<Variation> xpcVRN, DateTime? cutoffDate)
        //{
        //    List<(int, VRNStatusStats?)> lstStatus = new List<(int, VRNStatusStats?)>();
        //    string qString = @"SELECT v.VariationID, b.VrnStatusID, b.WaypointDate
        //                    FROM 
        //                        Variation v
        //                    OUTER APPLY
        //                        (SELECT TOP 1 VrnStatusID, WaypointDate 
        //                        FROM VRNWaypoint w_1
        //                        WHERE w_1.VariationID = v.VariationID
        //                     AND w_1.WaypointDate<@CutoffDate
        //                        ORDER BY W_1.WaypointDate DESC) b
        //                    WHERE v.ProjectID=@ProjectID";
        //    Session s = xpcVRN.Session;
        //    SelectedData result = s.ExecuteQuery(qString, new string[] { "@CutoffDate", "@ProjectID" }, new object[] { cutoffDate ?? SqlDateTime.MaxValue.Value, ProjectID });

        //    Dictionary<int, VRNStatusStats?> dctStatus = new Dictionary<int, VRNStatusStats?>();
        //    foreach (SelectStatementResultRow ssr in result.ResultSet[0].Rows)
        //    {
        //        int vID = QETotal.getIntegerFromNullableObject(ssr.Values[0]);
        //        int? sID = QETotal.getNullableIntegerFromNullableObject(ssr.Values[1]);
        //        VRNStatusStats? vs = null;
        //        if (sID != null)
        //        {
        //            if (sID.Value.In((int)Variation.VRNStatus.Approved, (int)Variation.VRNStatus.Conditionally_Approved, (int)Variation.VRNStatus.Approved_In_Principle))
        //                vs = VRNStatusStats.Approved;
        //            else if (sID.Value.In((int)Variation.VRNStatus.Notified, (int)Variation.VRNStatus.Submitted, (int)Variation.VRNStatus.Resubmit))
        //                vs = VRNStatusStats.Notified;
        //            else if (sID.Value.In((int)Variation.VRNStatus.Identified))
        //                vs = VRNStatusStats.Open;
        //        }
        //        dctStatus.Add(vID, vs);
        //    }

        //    foreach (var variation in xpcVRN)
        //    {
        //        if (dctStatus.ContainsKey(variation.VariationID))
        //            lstStatus.Add((variation.VariationID, dctStatus[variation.VariationID]));
        //        else if (cutoffDate == null || variation.CreatedOn <= cutoffDate.Value) lstStatus.Add((variation.VariationID, VRNStatusStats.Open));
        //    }

        //    return lstStatus;
        //}

    }
}
