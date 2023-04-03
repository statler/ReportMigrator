using cpReportDefinitions.Helpers;
using cpModel.Dtos.Lookup;
using cpModel.Dtos.Report;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static cpModel.Enums.ReportEnums;
using System.IO;

namespace cpReportDefinitions.LotReport
{
    public partial class rptLotConformance : rptTemplate, IReportOptions
    {
        public override string BaseReportName { get; set; } = "Conformance Report";
        LotReportDto _currLot;
        public int ShowOptions { get; set; }


        public rptLotConformance()
        {
            InitializeComponent();
            DisplayName = "Conformance Report";
            IsRegisterReport = true;
            DataSourceRowChanged += rptLotConformance_DataSourceRowChanged;
            BeforePrint += rptLotConformance_BeforePrint;
            Detail_TestResults.BeforePrint += Detail_TestResults_BeforePrint;
            Detail_Photo.BeforePrint += Detail_Photo_BeforePrint;
            Detail.BeforePrint += Detail_BeforePrint;
        }

        private void Detail_TestResults_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (sender as DetailBand).Controls.Clear();
            XtraReportBase r = (sender as DetailBand).Report;
            TestMethodLookupDto currTM = (r.GetCurrentRow() as TestMethodLookupDto);
            if (currTM == null) return;

            float availWidth = (PageWidth - Margins.Right - Margins.Right) * 0.98F;
            List<TestRequestTestReportDto> trTests = _currLot.Tests.Where(x => x.TestMethodId == currTM.TestMethodId).ToList();
            if (trTests.Where(x => x.Results.Count > 0).Count() > 0)
            {
                XRTable tbl = CreateQtyTable(currTM, trTests, availWidth);
                (sender as DetailBand).Controls.Add(tbl);
            }
            else e.Cancel = true;
        }

        private XRTable CreateQtyTable(TestMethodLookupDto currTM, List<TestRequestTestReportDto> trTestsForMethod, float availWidth)
        {
            var results = trTestsForMethod.SelectMany(x => x.Results).ToList();
            var resultFields = results.Where(x => x.TestResultFieldId != null)
                .GroupBy(x => x.TestResultFieldId)
                .Select(g => g.FirstOrDefault())
                .OrderBy(x => x.OrderId).ToList();

            float sampleWidth = 200;
            float resultWidth = Math.Min(300F, (availWidth - 100) / results.Count);
            Dictionary<int, List<double>> itemsForTotal = new Dictionary<int, List<double>>();
            XRTable testTable = new XRTable();

            testTable.Dpi = 254F;
            testTable.LocationF = new PointF(0, 20);
            testTable.SizeF = new SizeF(sampleWidth + resultWidth * results.Count, trTestsForMethod.Count() * 65);

            testTable.BeginInit();

            testTable.BorderWidth = 1;
            XRTableRow newTitleRow = new XRTableRow();
            newTitleRow.Dpi = 254F;
            testTable.Rows.Add(newTitleRow);
            newTitleRow.Cells.Add(ReportHelper.newTableCell(currTM.TestNumDesc, TextAlignment.MiddleLeft, 1, BorderSide.None, new Font("Tahoma", 10F, FontStyle.Bold)));

            XRTableRow newRow = new XRTableRow();
            newRow.Dpi = 254F;
            testTable.Rows.Add(newRow);

            //Create Table Header
            newRow.Cells.Add(ReportHelper.newTableCell("Sample", TextAlignment.MiddleCenter, sampleWidth / testTable.WidthF, BorderSide.All, new Font(Detail.Font, FontStyle.Bold)));

            foreach (TestResultReportDto result in resultFields)
                newRow.Cells.Add(ReportHelper.newTableCell(result.ResultFieldName, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));

            foreach (TestRequestTestReportDto test in trTestsForMethod.OrderBy(x => x.TestRequestNo).ThenBy(y => y.SampleId))
            {
                XRTableRow newTestRow = new XRTableRow();
                testTable.Rows.Add(newTestRow);
                newTestRow.Dpi = 254F;
                newTestRow.Cells.Add(ReportHelper.newTableCell(test.SampleId, TextAlignment.MiddleCenter, sampleWidth / testTable.WidthF, BorderSide.Left | BorderSide.Bottom | BorderSide.Right, Detail.Font));

                foreach (TestResultReportDto resultField in resultFields)
                {
                    TestResultReportDto testresult = test.Results.FirstOrDefault(x => x.TestResultFieldId == resultField.TestResultFieldId);
                    string resultString = testresult == null ? "" : testresult.Result;
                    double resultDBL = 0;
                    if (resultField.TestResultFieldId != null && double.TryParse(resultString, out resultDBL))
                    {
                        if (!itemsForTotal.ContainsKey(resultField.TestResultFieldId.Value)) itemsForTotal.Add(resultField.TestResultFieldId.Value, new List<double>());
                        itemsForTotal[resultField.TestResultFieldId.Value].Add(resultDBL);
                    }
                    newTestRow.Cells.Add(ReportHelper.newTableCell(resultString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                }
            }

            AddSummary(TotalType.TotalAverage, sampleWidth, resultWidth, itemsForTotal, resultFields, testTable);
            AddSummary(TotalType.LowerCV, sampleWidth, resultWidth, itemsForTotal, resultFields, testTable);
            AddSummary(TotalType.UpperCV, sampleWidth, resultWidth, itemsForTotal, resultFields, testTable);

            testTable.EndInit();
            return testTable;
        }

        private void AddSummary(TotalType typeTotal, float sampleWidth, float resultWidth, Dictionary<int, List<double>> itemsForTotal, List<TestResultReportDto> resultFields_sorted, XRTable testTable)
        {
            XRTableRow SumRow = new XRTableRow(); SumRow.Dpi = 254F;
            string rowTitle;
            if (typeTotal == TotalType.TotalAverage) rowTitle = "Average";
            else if (typeTotal == TotalType.LowerCV) rowTitle = "CV Lower";
            else rowTitle = "CV Upper";
            SumRow.Cells.Add(ReportHelper.newTableCell(rowTitle, TextAlignment.MiddleCenter, sampleWidth / testTable.WidthF, BorderSide.Left | BorderSide.Bottom | BorderSide.Right, Detail.Font));

            bool hasNonNAResult = false;
            foreach (TestResultReportDto resultField in resultFields_sorted)
            {
                string summaryString = "N/A";
                double summaryValue = -191919191919;
                if (resultField.TestResultFieldId != null && itemsForTotal.ContainsKey(resultField.TestResultFieldId.Value))
                {
                    List<double> resultFloat = itemsForTotal[resultField.TestResultFieldId.Value];
                    if (typeTotal == TotalType.TotalAverage) summaryValue = resultFloat.Average();
                    else
                    {
                        CharacteristicValue cv = new CharacteristicValue(resultFloat);
                        if (typeTotal == TotalType.LowerCV) summaryValue = cv.GetCVLower();
                        else summaryValue = cv.GetCVUpper();
                    }

                    if (summaryValue != -191919191919 && !double.IsNaN(summaryValue)) summaryString = summaryValue.ToString("#,###,##0.##");
                    if (summaryString != "N/A") hasNonNAResult = true;
                }
                SumRow.Cells.Add(ReportHelper.newTableCell(summaryString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
            }
            if (hasNonNAResult) testTable.Rows.Add(SumRow);
        }

        public enum TotalType
        {
            TotalAverage,
            LowerCV,
            UpperCV
        }

        private void Detail_Photo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as DetailBand).Report;
            if (r == null) return;

            try
            {
                PhotoLotReportDto np = (PhotoLotReportDto)r.GetCurrentRow();
                if (np != null && np.PhotoId != null)
                {
                    GetPhotoById(img, np.PhotoId.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cbReduced.Checked = (_currLot.TestRed ?? false);
            cbNormal.Checked = !(_currLot.TestRed ?? false);

            if (_currLot.DateRejected != null)
            {
                lbSignoffText.Text = $"This lot has been {DateRejectedString} and is not submitted for conformance.";
                lbDescription.Text = $"[{DateRejectedString}] " + _currLot.Description;
            }
            else
            {
                lbDescription.Text = _currLot.Description;
                lbSignoffText.Text = "This lot conforms in all respects with the standards and requirements specified in the " +
            "contract documents, the lot verification records are complete and any non conformances have been actioned in " +
            "accordance with the contract requirements";
            }

        }

        private void rptLotConformance_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currLot = GetCurrentRow() as LotReportDto;
            RecordReference = "Lot: " + _currLot.LotNumber;
        }

        private void rptLotConformance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var parameterEvent = new ProjectParameterEventArgs("signOffText");
                OnProjectParameterRequired(parameterEvent);
                string confString = parameterEvent.ParameterValue;
                if (!string.IsNullOrEmpty(confString)) lbSignoffText.Text = confString;
            }
            catch (Exception) { }

            if (ShouldIgnoreOptions) return;
            Dictionary<LotConfprintOption, List<XRControl>> reportSection = new Dictionary<LotConfprintOption, List<XRControl>>();

            reportSection.Add(LotConfprintOption.showWorkArea, new List<XRControl>() { xrpnWorkArea });
            reportSection.Add(LotConfprintOption.showOtherDetails, new List<XRControl>() { xrpnDetails });
            reportSection.Add(LotConfprintOption.showDates, new List<XRControl>() { xrpnDates });
            reportSection.Add(LotConfprintOption.showGeometry, new List<XRControl>() { bandGeometry });
            reportSection.Add(LotConfprintOption.showNotes, new List<XRControl>() { bandNotes });
            reportSection.Add(LotConfprintOption.showQty, new List<XRControl>() { DetailReport_LotQuant });
            reportSection.Add(LotConfprintOption.showQVC, new List<XRControl>() { DetailReport_LotITP });
            reportSection.Add(LotConfprintOption.showNCR, new List<XRControl>() { DetailReport_NCR });
            reportSection.Add(LotConfprintOption.showTestReq, new List<XRControl>() { DetailReport_TR });
            reportSection.Add(LotConfprintOption.showTestResult, new List<XRControl>() { DetailReport_TestResults });
            reportSection.Add(LotConfprintOption.showATP, new List<XRControl>() { DetailReport_ATP });
            reportSection.Add(LotConfprintOption.showRelated, new List<XRControl>() { DetailReport_related });
            reportSection.Add(LotConfprintOption.showPhoto, new List<XRControl>() { DetailReport_Photo });
            reportSection.Add(LotConfprintOption.showVRN, new List<XRControl>() { DetailReport_Variation });
            reportSection.Add(LotConfprintOption.showSignOff, new List<XRControl>() { bandSignoff });
            reportSection.Add(LotConfprintOption.showAppSignOff, new List<XRControl>() { bandApprsig });
            reportSection.Add(LotConfprintOption.showDirectApproval, new List<XRControl>() { DetailReport_DirectApprovals });

            foreach (KeyValuePair<LotConfprintOption, List<XRControl>> item in reportSection)
                foreach (XRControl xrControl in item.Value)
                    xrControl.Visible = HasFlag(ShowOptions, (int)item.Key);
        }

    }
}
