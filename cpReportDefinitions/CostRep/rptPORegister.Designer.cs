//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cpReportDefinitions.CostRep {
    
    public partial class rptPORegister : rptTemplate
    {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "cpReportDefinitions.CostRep.rptPORegister.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.ReportFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("ReportFooter");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.lbPOTotalVal = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbPOTotalVal");
            this.xrLabel3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel3");
            this.xrLabel2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel2");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");
            this.headPanel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("headPanel");
            this.lbReportHeading = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbReportHeading");
            this.lbProject = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbProject");
            this.lbRecordReference = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecordReference");
            this.pbLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pbLogo");
            this.lbFooterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFooterText");
            this.xrPageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("xrPageInfo1");
            this.xrLine1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine1");
            this.lbPOTotalFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbPOTotalFooter");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(cpModel.Dtos.Report.PurchaseOrderReportDto);
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lbPOTotalVal;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPanel headPanel;
        private DevExpress.XtraReports.UI.XRLabel lbReportHeading;
        private DevExpress.XtraReports.UI.XRLabel lbProject;
        private DevExpress.XtraReports.UI.XRLabel lbRecordReference;
        private DevExpress.XtraReports.UI.XRPictureBox pbLogo;
        private DevExpress.XtraReports.UI.XRLabel lbFooterText;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel lbPOTotalFooter;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    }
}
