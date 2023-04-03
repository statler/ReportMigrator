using System;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.NCRRep
{
    public partial class rptNCRRegister_condensed
    {
        public override string BaseReportName { get; set; } = "NCR Register (condensed)";

        public rptNCRRegister_condensed()
        {
            InitializeComponent();
            ReportTitle = "NCR Register (condensed)";
            IsRegisterReport = true;
        }
    }
}
