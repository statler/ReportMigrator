using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;
using System;

namespace cpReportDefinitions.TestReqRep
{
    public partial class rptTR : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Test Request";
        public bool InclCompliance { get; set; }
        TestRequestReportDto _currTR;
        public rptTR()
        {
            InitializeComponent();
            ReportTitle = "Test Request";
            DataSourceRowChanged += rptTR_DataSourceRowChanged;
            Detail.BeforePrint += Detail_BeforePrint;
            xrCompliance.BeforePrint += xrCompliance_BeforePrint;
            xrComplianceGrouped.BeforePrint += xrCompliance_BeforePrint;
            sbCompliance.BeforePrint += sbCompliance_BeforePrint;
            sbComplianceGrouped.BeforePrint += sbCompliance_BeforePrint;
        }



        public void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int locMeth = _currTR?.LocateMethod ?? 1;
                if (locMeth == 0) locMeth = 1;
                DetailReport_TestList.Visible = locMeth != 1;
                DetailReport_TestGrouped.Visible = locMeth == 1;
                lbLocationMethod.Text = (new string[] { "Tester Locates", "Random Stratified Testing", "Location Specified" })[locMeth - 1];
            }
            catch (Exception)
            {
            }

        }

        private void rptTR_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currTR = GetCurrentRow() as TestRequestReportDto;
            RecordReference = "TR: " + _currTR.TestRequestNo;
        }

        private void xrCompliance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            (sender as XRRichText).Html = GetHtmlWithDefaultFormat(_report, "ComplianceReq", xrCompliance.Font);
        }

        private void sbCompliance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!InclCompliance) e.Cancel = true;
        }
    }
}
