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
    
    public partial class rptApprovalRegisterDetail : rptTemplate {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "cpReportDefinitions.ConformanceRep.rptApprovalRegisterDetail.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.DetailReport = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailReportBand>("DetailReport");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.xrLabel10 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel10");
            this.xrLabel5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel5");
            this.xrCheckBox1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRCheckBox>("xrCheckBox1");
            this.xrLabel3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel3");
            this.xrLabel2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel2");
            this.lbFrom = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFrom");
            this.xrLabel14 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel14");
            this.xrLabel8 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel8");
            this.lbRequestDate = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRequestDate");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");
            this.xrREReqSub = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRRichText>("xrREReqSub");
            this.xrLine1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine1");
            this.headPanel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("headPanel");
            this.xrLabel4 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel4");
            this.xrLabel18 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel18");
            this.xrLabel12 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel12");
            this.xrLabel11 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel11");
            this.xrLabel6 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel6");
            this.xrLabel9 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel9");
            this.xrLabel7 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel7");
            this.lbReportHeading = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbReportHeading");
            this.lbProject = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbProject");
            this.lbRecordReference = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecordReference");
            this.pbLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pbLogo");
            this.lbFooterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFooterText");
            this.xrPageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("xrPageInfo1");
            this.Detail1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail1");
            this.ReportHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportHeaderBand>("ReportHeader");
            this.xrLabel13 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel13");
            this.xrLabel15 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel15");
            this.xrWorkflowComment = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRRichText>("xrWorkflowComment");
            this.xrLabel19 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel19");
            this.xrLabel16 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel16");
            this.ReportFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("ReportFooter");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(cpModel.Dtos.Report.ApprovalListReportDto);

            // Calculated Fields
            this.calcToCsv = reportInitializer.GetCalculatedField("calcToCsv");
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRCheckBox xrCheckBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel lbFrom;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel lbRequestDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRRichText xrREReqSub;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRPanel headPanel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel lbReportHeading;
        private DevExpress.XtraReports.UI.XRLabel lbProject;
        private DevExpress.XtraReports.UI.XRLabel lbRecordReference;
        private DevExpress.XtraReports.UI.XRPictureBox pbLogo;
        private DevExpress.XtraReports.UI.XRLabel lbFooterText;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRRichText xrWorkflowComment;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.CalculatedField calcToCsv;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
    }
}
