//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cpReportDefinitions.DocRep.ContractNotices {
    
    public partial class rptContractNoticeRaw : rptTemplate {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "cpReportDefinitions.DocRep.ContractNotices.rptContractNoticeRaw.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.rtRequestDetails = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRRichText>("rtRequestDetails");
            this.sbResponse = reportInitializer.GetControl<DevExpress.XtraReports.UI.SubBand>("sbResponse");
            this.xrLabel17 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel17");
            this.xrLabel18 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel18");
            this.xrPageBreak1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageBreak>("xrPageBreak1");
            this.xrLabel14 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel14");
            this.xrLabel15 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel15");
            this.xrLabel10 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel10");
            this.xrLabel11 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel11");
            this.rtResponse = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRRichText>("rtResponse");
            this.xrLabel2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel2");
            this.headPanel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("headPanel");
            this.lbReportHeading = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbReportHeading");
            this.lbProject = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbProject");
            this.lbRecordReference = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecordReference");
            this.pbLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pbLogo");
            this.lbFooterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFooterText");
            this.xrPageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("xrPageInfo1");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(cpModel.Dtos.Report.ContractNoticeReportDto);

            // Styles
            this.Title = reportInitializer.GetStyle("Title");
            this.FieldCaption = reportInitializer.GetStyle("FieldCaption");
            this.PageInfo = reportInitializer.GetStyle("PageInfo");
            this.DataField = reportInitializer.GetStyle("DataField");
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRRichText rtRequestDetails;
        private DevExpress.XtraReports.UI.SubBand sbResponse;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRRichText rtResponse;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRPanel headPanel;
        private DevExpress.XtraReports.UI.XRLabel lbReportHeading;
        private DevExpress.XtraReports.UI.XRLabel lbProject;
        private DevExpress.XtraReports.UI.XRLabel lbRecordReference;
        private DevExpress.XtraReports.UI.XRPictureBox pbLogo;
        private DevExpress.XtraReports.UI.XRLabel lbFooterText;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
    }
}
