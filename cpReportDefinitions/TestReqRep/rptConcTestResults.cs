using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using cpModel.Dtos;
using cpModel.Dtos.Report;
using cpModel.Enums;
using cpModel.Models;
using cpReportDefinitions.Helpers;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.TestReqRep
{
    public partial class rptConcTestResults
    {
        public override string BaseReportName { get; set; } = "Concrete Test Result";

        TestMethodReportDto_concrete _currTestMethod;
        ConcreteTestTypes testTypes;
        List<TestResultFieldDto> resFields;
        int NoResultCols = 0;
        double fc;
        double ft;

        public rptConcTestResults()
        {
            InitializeComponent();
            Detail.BeforePrint += Detail_BeforePrint;
            DataSourceRowChanged += Report1_DataSourceRowChanged;
            ReportTitle = "Concrete Test Results";
            IsRegisterReport = true;
        }

        private void Report1_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currTestMethod = GetCurrentRow() as TestMethodReportDto_concrete;
            testTypes = _currTestMethod.Concrete_TestTypes;
            resFields = _currTestMethod.CylinderResultFields;
            fc = _currTestMethod.Fc;
            ft = _currTestMethod.Ft;
            RecordReference = $"Test Method: {_currTestMethod.TestNumDesc}";
            GetColCount();
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_currTestMethod == null) return;
            Detail.Controls.Clear();

            float availWidth = (PageWidth - Margins.Right - Margins.Right) * 0.98F;
            List<TestResultFieldDto> trFields = _currTestMethod.ResultFields.ToList();
            if (trFields.Count > 0) CreateTable(_currTestMethod, _currTestMethod.Tests.Where(x => x.TestMethodId == _currTestMethod.TestMethodId).ToList(), availWidth);
        }


        private void CreateTable(TestMethodReportDto currTM, List<TestRequestTestReportDto> tests, float availWidth)
        {
            float rowHeadWidth = 200;
            float resultWidth = Math.Min(300F, (availWidth - rowHeadWidth * 3) / NoResultCols);
            Dictionary<TestResultField, List<double>> itemsForTotal = new Dictionary<TestResultField, List<double>>();
            XRTable testTable = new XRTable();

            testTable.Dpi = 254F;
            testTable.LocationF = new PointF(0, 20);
            testTable.SizeF = new SizeF(rowHeadWidth * 3 + resultWidth * NoResultCols, 5);

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
            newRow.Cells.Add(ReportHelper.newTableCell("Sample", TextAlignment.MiddleCenter, rowHeadWidth / testTable.WidthF, BorderSide.All, new Font(Detail.Font, FontStyle.Bold)));
            newRow.Cells.Add(ReportHelper.newTableCell("Test Date", TextAlignment.MiddleCenter, rowHeadWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
            newRow.Cells.Add(ReportHelper.newTableCell("Lot Number", TextAlignment.MiddleCenter, rowHeadWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));

            foreach (var res_Field in resFields)
            {
                newRow.Cells.Add(ReportHelper.newTableCell(res_Field.ResultFieldName, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
            }

            if (HasFlag(testTypes, ConcreteTestTypes.fsDiff)) newRow.Cells.Add(ReportHelper.newTableCell("Cyl. Range", TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
            if (HasFlag(testTypes, ConcreteTestTypes.fsLT09fc)) newRow.Cells.Add(ReportHelper.newTableCell("f's", TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
            if (HasFlag(testTypes, ConcreteTestTypes.fs3xLotGTfc)) newRow.Cells.Add(ReportHelper.newTableCell("Av[3] f's (Lot)", TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
            if (HasFlag(testTypes, ConcreteTestTypes.fs3xAnyLTfcft)) newRow.Cells.Add(ReportHelper.newTableCell("Av[3] f's (All)", TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));

            List<TestFS> fsList = new List<TestFS>();
            Dictionary<int, List<float>> lotfs = new Dictionary<int, List<float>>();
            List<TestRequestTestReportDto> testOrderByDate = tests.OrderBy(x => x.TestDate).ThenBy(y => y.LotNumber).ToList();

            foreach (var test in testOrderByDate)
            {
                XRTableRow newTestRow = new XRTableRow();
                testTable.Rows.Add(newTestRow);
                newTestRow.Dpi = 254F;
                newTestRow.Cells.Add(ReportHelper.newTableCell(test.SampleId, TextAlignment.MiddleCenter, rowHeadWidth / testTable.WidthF, BorderSide.Left | BorderSide.Bottom | BorderSide.Right, Detail.Font));
                newTestRow.Cells.Add(ReportHelper.newTableCell(test.TestDate?.ToShortDateString(), TextAlignment.MiddleCenter, rowHeadWidth / testTable.WidthF, BorderSide.Left | BorderSide.Bottom | BorderSide.Right, Detail.Font));
                newTestRow.Cells.Add(ReportHelper.newTableCell(test.LotNumber, TextAlignment.MiddleCenter, rowHeadWidth / testTable.WidthF, BorderSide.Left | BorderSide.Bottom | BorderSide.Right, Detail.Font));

                List<float> fsSample = new List<float>();

                //Add valid results to the output and the appropriate lot and the mini list from which fs is calculated
                foreach (var resultField in resFields)
                {
                    var testresult = test.Results.FirstOrDefault(x => x.TestResultFieldId == resultField.TestResultFieldId);
                    string resultString = testresult == null ? "" : testresult.Result;
                    float fsCylFloat = 0;

                    if (float.TryParse(resultString, out fsCylFloat)) fsSample.Add(fsCylFloat);
                    else resultString = "";

                    newTestRow.Cells.Add(ReportHelper.newTableCell(resultString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                }

                //Work out if this is valid using max range of cylinders. Calculate fs when valid
                float fsFloat = -1;
                bool cylRangeComply = true;
                if (fsSample.Count < 2) cylRangeComply = false;
                else if (fsSample.Count == 2)
                {
                    if ((fsSample.Max() - fsSample.Min()) > 2) cylRangeComply = false;
                    else fsFloat = fsSample.Average();
                }
                else if (fsSample.Count == 3)
                {
                    if ((fsSample.Max() - fsSample.Min()) > 3)
                    {
                        fsSample.Remove(fsSample.Min());
                        cylRangeComply = false;
                        if ((fsSample.Max() - fsSample.Min()) <= 2) fsFloat = fsSample.Average();
                    }
                    else fsFloat = fsSample.Average();
                }

                //Add valid fs to the lists for lot and all
                if (fsFloat > -1)
                {
                    fsList.Add(new TestFS(test, fsFloat));
                    if (test.LotId != null)
                    {
                        if (!lotfs.ContainsKey(test.LotId.Value)) lotfs.Add(test.LotId.Value, new List<float>());
                        lotfs[test.LotId.Value].Add(fsFloat);
                    }
                }
                else fsList.Add(new TestFS(test, -1));

                if (HasFlag(testTypes, ConcreteTestTypes.fsDiff))
                {
                    string diffToString = "-";
                    if (fsSample.Count > 1)
                    {
                        diffToString = (fsSample.Max() - fsSample.Min()).ToString("#,##0.##");
                        if (!cylRangeComply) diffToString += " *";
                    }
                    newTestRow.Cells.Add(ReportHelper.newTableCell(diffToString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                }

                if (HasFlag(testTypes, ConcreteTestTypes.fsLT09fc))
                {
                    string fsString = "-";
                    if (fsFloat > -1)
                    {
                        fsString = fsFloat.ToString("#,##0.##");
                        if (fsFloat < 0.9 * fc) fsString += " *";
                    }
                    newTestRow.Cells.Add(ReportHelper.newTableCell(fsString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                }

                List<TestFS> validTestfs = fsList.Where(x => x.fs != -1).ToList();
                if (HasFlag(testTypes, ConcreteTestTypes.fs3xLotGTfc) || HasFlag(testTypes, ConcreteTestTypes.fs3xLotLT14fc))
                {
                    string fsString = "-";
                    if (test.LotId != null && lotfs.ContainsKey(test.LotId.Value) && fsFloat > -1)
                    {
                        List<float> fsLotList = lotfs[test.LotId.Value];
                        int LotListCount = fsLotList.Count();
                        if (LotListCount >= 3)
                        {
                            float[] aggList = new float[3];
                            int ix = fsLotList.Count() - 3;
                            fsLotList.CopyTo(ix, aggList, 0, 3);
                            float aggListToListAverage = aggList.ToList().Average();
                            fsString = aggListToListAverage.ToString("#,##0.##");
                            if (aggListToListAverage < fc) fsString += "*";
                            if (aggListToListAverage > 1.4 * fc) fsString += "*";
                        }
                    }
                    newTestRow.Cells.Add(ReportHelper.newTableCell(fsString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                }

                if (HasFlag(testTypes, ConcreteTestTypes.fs3xAnyLTfcft))
                {
                    string fsString = "-";
                    if (validTestfs.Count() >= 3 && fsFloat > -1)
                    {
                        float[] aggList = new float[3];
                        int ix = validTestfs.Count() - 3;
                        validTestfs.Select(x => x.fs).ToList().CopyTo(ix, aggList, 0, 3);
                        float aggListToListAverage = aggList.ToList().Average();
                        fsString = aggListToListAverage.ToString("#,##0.##");
                        if (aggListToListAverage < 0.5 * (fc + ft)) fsString += "*";
                    }
                    newTestRow.Cells.Add(ReportHelper.newTableCell(fsString, TextAlignment.MiddleCenter, resultWidth / testTable.WidthF, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                }

            }

            double meanTargetStrength = Math.Round(0.5 * (fc + ft), 2);
            double targetSdev = Math.Round((ft - fc) / 1.65, 2);

            XRTableRow newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            newResultRow.Cells.Add(ReportHelper.newTableCell("", TextAlignment.MiddleCenter, 1, BorderSide.None, Detail.Font));
            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            string stats = String.Format("f'c={0:#,##0.##}", fc);
            newResultRow.Cells.Add(ReportHelper.newTableCell(stats, TextAlignment.MiddleLeft, 1, BorderSide.None, Detail.Font));

            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            newResultRow.Cells.Add(ReportHelper.newTableCell("", TextAlignment.MiddleCenter, 1, BorderSide.None, Detail.Font));
            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            stats = String.Format("f't={0:#,##0.##}", ft);
            newResultRow.Cells.Add(ReportHelper.newTableCell(stats, TextAlignment.MiddleLeft, 1, BorderSide.None, Detail.Font));

            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            newResultRow.Cells.Add(ReportHelper.newTableCell("", TextAlignment.MiddleCenter, 1, BorderSide.None, Detail.Font));
            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            stats = String.Format("(f'c+f't)/2={0:#,##0.##}", meanTargetStrength);
            newResultRow.Cells.Add(ReportHelper.newTableCell(stats, TextAlignment.MiddleLeft, 1, BorderSide.None, Detail.Font));

            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            newResultRow.Cells.Add(ReportHelper.newTableCell("", TextAlignment.MiddleCenter, 1, BorderSide.None, Detail.Font));
            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            stats = String.Format("Target SDev={0:#,##0.##}", targetSdev);
            newResultRow.Cells.Add(ReportHelper.newTableCell(stats, TextAlignment.MiddleLeft, 1, BorderSide.None, Detail.Font));

            List<float> validfsAll = fsList.Select(x => x.fs).Where(x => x != -1).ToList();
            string sampleSDAll = "N/A";
            if (validfsAll.Count >= 2) sampleSDAll = StatisticsExtensions.StandardDeviationSample(validfsAll.ToList()).ToString("#,##0.##");

            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            newResultRow.Cells.Add(ReportHelper.newTableCell("", TextAlignment.MiddleCenter, 1, BorderSide.None, Detail.Font));
            newResultRow = new XRTableRow();
            testTable.Rows.Add(newResultRow);
            newResultRow.Dpi = 254F;
            stats = String.Format("SDev of valid samples={0:#,##0.##}", sampleSDAll);
            newResultRow.Cells.Add(ReportHelper.newTableCell(stats, TextAlignment.MiddleLeft, 1, BorderSide.None, Detail.Font));

            XRTable windowTable = new XRTable();
            if (HasFlag(testTypes, ConcreteTestTypes.fsAnyLTfcft10week))
            {
                // If 10 tests in 28 day requirement is specified, find windows where this condition is met.
                int testListCount = fsList.Count;
                // Need at least ten in the list
                if (testListCount > 10)
                {
                    windowTable.Dpi = 254F;
                    windowTable.LocationF = new PointF(0, testTable.BottomF + 25);
                    windowTable.SizeF = new SizeF(rowHeadWidth * 5, 5);

                    windowTable.BeginInit();

                    windowTable.BorderWidth = 1;

                    bool spacerPrinted = false;
                    //Maximum date difference must be at least 28 days for 10 or more tests
                    int i = 0;
                    while (i < (testListCount - 9))
                    {

                        int j = i;
                        List<float> validfs = new List<float>();
                        while (j < testListCount && (fsList[j].test.TestDate.Value.Subtract(fsList[i].test.TestDate.Value).Days <= 28))
                        {
                            if (fsList[j].fs != -1) validfs.Add(fsList[j].fs);
                            j++;
                        }
                        j--;
                        //Are there enough tests to check for compliance?
                        int noTestsInWindow = (j - i + 1);
                        if (noTestsInWindow >= 10)
                        {
                            double avefs = Math.Round(validfs.Average(), 2);
                            string sampleSD = "N/A";
                            if (validfs.Count >= 2) sampleSD = StatisticsExtensions.StandardDeviationSample(validfs.ToList()).ToString("#,##0.##");

                            //Print header if not already printed
                            if (!spacerPrinted)
                            {
                                newResultRow = new XRTableRow();
                                testTable.Rows.Add(newResultRow);
                                newResultRow.Dpi = 254F;
                                newResultRow.Cells.Add(ReportHelper.newTableCell("Date Start", TextAlignment.MiddleCenter, 1, BorderSide.All, new Font(Detail.Font, FontStyle.Bold)));
                                newResultRow.Cells.Add(ReportHelper.newTableCell("Date End", TextAlignment.MiddleCenter, 1, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
                                newResultRow.Cells.Add(ReportHelper.newTableCell("No. Tests", TextAlignment.MiddleCenter, 1, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
                                newResultRow.Cells.Add(ReportHelper.newTableCell("Ave f's", TextAlignment.MiddleCenter, 1, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
                                if (HasFlag(testTypes, ConcreteTestTypes.stdev)) newResultRow.Cells.Add(ReportHelper.newTableCell("St. Dev.", TextAlignment.MiddleCenter, 1, BorderSide.Top | BorderSide.Bottom | BorderSide.Right, new Font(Detail.Font, FontStyle.Bold)));
                                spacerPrinted = true;
                            }

                            newResultRow = new XRTableRow();
                            testTable.Rows.Add(newResultRow);
                            newResultRow.Dpi = 254F;
                            newResultRow.Cells.Add(ReportHelper.newTableCell(fsList[i].test.TestDate.Value.ToShortDateString(), TextAlignment.MiddleCenter, 1, BorderSide.Left | BorderSide.Bottom | BorderSide.Right, Detail.Font));
                            newResultRow.Cells.Add(ReportHelper.newTableCell(fsList[j].test.TestDate.Value.ToShortDateString(), TextAlignment.MiddleCenter, 1, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                            newResultRow.Cells.Add(ReportHelper.newTableCell(noTestsInWindow.ToString(), TextAlignment.MiddleCenter, 1, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                            string avefsToString = avefs.ToString("#,##0.##");
                            if (avefs < meanTargetStrength) avefsToString += " *";
                            newResultRow.Cells.Add(ReportHelper.newTableCell(avefsToString, TextAlignment.MiddleCenter, 1, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                            if (HasFlag(testTypes, ConcreteTestTypes.stdev)) newResultRow.Cells.Add(ReportHelper.newTableCell(sampleSD, TextAlignment.MiddleCenter, 1, BorderSide.Bottom | BorderSide.Right, Detail.Font));
                        }
                        i = j + 1;
                    }
                }
            }

            testTable.EndInit();
            Detail.Controls.Add(testTable);
        }

        private void GetColCount()
        {
            NoResultCols += resFields.Count();
            if (HasFlag(testTypes, ConcreteTestTypes.fsDiff)) NoResultCols++;
            if (HasFlag(testTypes, ConcreteTestTypes.fsLT09fc)) NoResultCols++;
            if (HasFlag(testTypes, ConcreteTestTypes.fs3xAnyLTfcft)) NoResultCols++;
            if (HasFlag(testTypes, ConcreteTestTypes.fs3xLotGTfc) || HasFlag(testTypes, ConcreteTestTypes.fs3xLotLT14fc)) NoResultCols++;
        }



        public static bool HasFlag(ConcreteTestTypes item, ConcreteTestTypes query)
        {
            return ((item & query) == query);
        }

        public enum TotalType
        {
            TotalAverage,
            LowerCV,
            UpperCV
        }

    }
    public class TestFS
    {
        public TestRequestTestReportDto test { get; set; }
        public float fs { get; set; }

        public TestFS()
        {

        }

        /// <summary>
        /// Initializes a new instance of the TestFS class.
        /// </summary>
        public TestFS(TestRequestTestReportDto test, float fs)
        {
            this.test = test;
            this.fs = fs;
        }
    }
}
