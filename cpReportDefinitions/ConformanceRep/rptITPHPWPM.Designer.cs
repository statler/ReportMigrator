//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cpReportDefinitions.ConformanceRep {
    
    public partial class rptITPHpWpM : rptTemplate
    {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "cpReportDefinitions.ConformanceRep.rptITPHPWPM.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.ITPDetailReport = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailReportBand>("ITPDetailReport");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");
            this.headPanel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("headPanel");
            this.lbReportHeading = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbReportHeading");
            this.lbProject = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbProject");
            this.lbRecordReference = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecordReference");
            this.pbLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pbLogo");
            this.lbFooterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFooterText");
            this.xrPageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("xrPageInfo1");
            this.lblFtrCenterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lblFtrCenterText");
            this.ITPDetail_Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("ITPDetail_Detail");
            this.TestingReport = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailReportBand>("TestingReport");
            this.ReportFooter1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("ReportFooter1");
            this.xrpnlSundry = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("xrpnlSundry");
            this.lbDetailNo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbDetailNo");
            this.xrrtDescription = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRRichText>("xrrtDescription");
            this.lbhRecords = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbhRecords");
            this.lbhClause = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbhClause");
            this.lbhMethodInsp = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbhMethodInsp");
            this.lbResp = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbResp");
            this.lbMethodInsp = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbMethodInsp");
            this.lbRecords = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecords");
            this.lbClause = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbClause");
            this.lbhResp = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbhResp");
            this.TestingReport_Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("TestingReport_Detail");
            this.ReportFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("ReportFooter");
            this.xrLabel11 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel11");
            this.xrLabel7 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel7");
            this.xrLabel12 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel12");
            this.lblFreqRed = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lblFreqRed");
            this.lblFreqNorm = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lblFreqNorm");
            this.xrLabel13 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel13");
            this.xrrtCompliance = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRRichText>("xrrtCompliance");
            this.lblIndex = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lblIndex");
            this.xrLine1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine1");
            this.xrLine3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine3");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(cpModel.Dtos.Report.ItpReportDto);

            // Styles
            this.Title = reportInitializer.GetStyle("Title");
            this.FieldCaption = reportInitializer.GetStyle("FieldCaption");
            this.PageInfo = reportInitializer.GetStyle("PageInfo");
            this.DataField = reportInitializer.GetStyle("DataField");
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.DetailReportBand ITPDetailReport;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPanel headPanel;
        private DevExpress.XtraReports.UI.XRLabel lbReportHeading;
        private DevExpress.XtraReports.UI.XRLabel lbProject;
        private DevExpress.XtraReports.UI.XRLabel lbRecordReference;
        private DevExpress.XtraReports.UI.XRPictureBox pbLogo;
        private DevExpress.XtraReports.UI.XRLabel lbFooterText;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel lblFtrCenterText;
        private DevExpress.XtraReports.UI.DetailBand ITPDetail_Detail;
        private DevExpress.XtraReports.UI.DetailReportBand TestingReport;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter1;
        private DevExpress.XtraReports.UI.XRPanel xrpnlSundry;
        private DevExpress.XtraReports.UI.XRLabel lbDetailNo;
        private DevExpress.XtraReports.UI.XRRichText xrrtDescription;
        private DevExpress.XtraReports.UI.XRLabel lbhRecords;
        private DevExpress.XtraReports.UI.XRLabel lbhClause;
        private DevExpress.XtraReports.UI.XRLabel lbhMethodInsp;
        private DevExpress.XtraReports.UI.XRLabel lbResp;
        private DevExpress.XtraReports.UI.XRLabel lbMethodInsp;
        private DevExpress.XtraReports.UI.XRLabel lbRecords;
        private DevExpress.XtraReports.UI.XRLabel lbClause;
        private DevExpress.XtraReports.UI.XRLabel lbhResp;
        private DevExpress.XtraReports.UI.DetailBand TestingReport_Detail;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel lblFreqRed;
        private DevExpress.XtraReports.UI.XRLabel lblFreqNorm;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRRichText xrrtCompliance;
        private DevExpress.XtraReports.UI.XRLabel lblIndex;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    }
}
