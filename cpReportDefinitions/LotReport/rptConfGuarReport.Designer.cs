//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cpReportDefinitions.LotReport {
    
    public partial class rptConfGuarReport : rptTemplate {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "cpReportDefinitions.LotReport.rptConfGuarReport.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.ghStatus = reportInitializer.GetControl<DevExpress.XtraReports.UI.GroupHeaderBand>("ghStatus");
            this.ReportFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("ReportFooter");
            this.DetailReport = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailReportBand>("DetailReport");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.lbStatusDate = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbStatusDate");
            this.xrLabel4 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel4");
            this.xrLabel2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel2");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");
            this.headPanel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("headPanel");
            this.lbReportHeading = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbReportHeading");
            this.lbProject = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbProject");
            this.lbRecordReference = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecordReference");
            this.pbLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pbLogo");
            this.lbFooterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFooterText");
            this.xrPageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("xrPageInfo1");
            this.lbStatusDateHead = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbStatusDateHead");
            this.xrLabel7 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel7");
            this.xrLabel6 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel6");
            this.Opened = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("Opened");
            this.xrLabel5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel5");
            this.xrLine4 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine4");
            this.xrLabel25 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel25");
            this.xrLine5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine5");
            this.xrLine3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine3");
            this.xrLabel21 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel21");
            this.xrLabel11 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel11");
            this.pnlConfDec = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("pnlConfDec");
            this.xrLabel3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel3");
            this.pnlGuarDec = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("pnlGuarDec");
            this.xrLabel8 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel8");
            this.xrLabel10 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel10");
            this.xrLabel12 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel12");
            this.xrLabel9 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel9");
            this.Detail1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail1");
            this.ReportHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportHeaderBand>("ReportHeader");
            this.xrLabel13 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel13");
            this.xrLabel14 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel14");
            this.xrLabel15 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel15");
            this.xrLabel16 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel16");
            this.xrLabel17 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel17");
            this.xrLabel18 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel18");
            this.xrLabel19 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel19");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(cpModel.Dtos.Report.LotReportDto);
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand ghStatus;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lbStatusDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPanel headPanel;
        private DevExpress.XtraReports.UI.XRLabel lbReportHeading;
        private DevExpress.XtraReports.UI.XRLabel lbProject;
        private DevExpress.XtraReports.UI.XRLabel lbRecordReference;
        private DevExpress.XtraReports.UI.XRPictureBox pbLogo;
        private DevExpress.XtraReports.UI.XRLabel lbFooterText;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel lbStatusDateHead;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel Opened;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRPanel pnlConfDec;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPanel pnlGuarDec;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    }
}
