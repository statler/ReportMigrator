//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cpReportDefinitions.PaymentRep {
    
    public partial class rptMeasureUp : rptTemplate {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "cpReportDefinitions.PaymentRep.rptMeasureUp.repx");

            // Controls
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.GroupHeader1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.GroupHeaderBand>("GroupHeader1");
            this.ReportFooter1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportFooterBand>("ReportFooter1");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.xrLabel5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel5");
            this.lbQty = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbQty");
            this.lbEffQty = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbEffQty");
            this.xrLabel7 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel7");
            this.xrLabel4 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel4");
            this.xrLabel2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel2");
            this.xrLabel3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel3");
            this.xrLabel8 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel8");
            this.headPanel = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("headPanel");
            this.lbReportHeading = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbReportHeading");
            this.lbProject = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbProject");
            this.lbRecordReference = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbRecordReference");
            this.pbLogo = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pbLogo");
            this.lbFooterText = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("lbFooterText");
            this.xrPageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("xrPageInfo1");
            this.xrLabel1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel1");
            this.pnlVerAuth = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPanel>("pnlVerAuth");
            this.xrLine6 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine6");
            this.xrLine3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine3");
            this.xrLabel9 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel9");
            this.xrLine2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine2");
            this.xrLine5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLine>("xrLine5");
            this.xrLabel10 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel10");
            this.xrLabel11 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel11");
            this.xrLabel12 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("xrLabel12");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(cpModel.Dtos.Report.LotQuantityReportDto);

            // Styles
            this.Title = reportInitializer.GetStyle("Title");
            this.FieldCaption = reportInitializer.GetStyle("FieldCaption");
            this.PageInfo = reportInitializer.GetStyle("PageInfo");
            this.DataField = reportInitializer.GetStyle("DataField");
        }
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter1;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lbQty;
        private DevExpress.XtraReports.UI.XRLabel lbEffQty;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRPanel headPanel;
        private DevExpress.XtraReports.UI.XRLabel lbReportHeading;
        private DevExpress.XtraReports.UI.XRLabel lbProject;
        private DevExpress.XtraReports.UI.XRLabel lbRecordReference;
        private DevExpress.XtraReports.UI.XRPictureBox pbLogo;
        private DevExpress.XtraReports.UI.XRLabel lbFooterText;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPanel pnlVerAuth;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    }
}
