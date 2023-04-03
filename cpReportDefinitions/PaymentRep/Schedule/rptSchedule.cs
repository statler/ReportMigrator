using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptSchedule : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Schedule Report";

        ScheduleFlatReportDto currSI;
        const float DescLeft = 0F;
        const float DescMaxWidth = 1106F;
        const float Indent = 50F;

        public rptSchedule()
        {
            InitializeComponent();
            ReportTitle = "Schedule Report";
            BeforePrint += RptSchedule_BeforePrint;
            DataSourceRowChanged += RptSchedule_DataSourceRowChanged;
            Detail.BeforePrint += Detail_BeforePrint;
        }

        private void RptSchedule_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataSource == null) e.Cancel = true;
            List<ScheduleFlatReportDto> dsAsList = DataSource as List<ScheduleFlatReportDto>;
            decimal totalVal = dsAsList.Where(x => !x.IsSummaryLine).Sum(x => x.SellTotal) ?? 0;
            lbGrandSellTotal.Text = string.Format("{0:$#,###,###,##0.00}", totalVal);
            if (dsAsList.Count == 0) e.Cancel = true;
        }


        private void RptSchedule_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            currSI = GetCurrentRow() as ScheduleFlatReportDto;

        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRLabel[] lbls = { lbUnit, lbSellRate, lbSellTotal };
            Font font = new Font(lbDesc.Font, FontStyle.Regular);
            if (currSI.IsHeading || currSI.IsSummaryLine)
            {
                if (currSI.Level == 0) font = new Font(font, FontStyle.Bold);
                if (currSI.Level == 1) font = new Font(font, FontStyle.Underline);
                lbSellTotal.LeftF = 1580F;
                lbSellTotal.WidthF = 291;
            }
            else
            {
                lbSellTotal.LeftF = 1651;
                lbSellTotal.WidthF = 220;
            }
            if (currSI.IsSummaryLine)
            {
                font = new Font(font, font.Style | FontStyle.Italic);
            }
            lbls.ToList().ForEach(x => x.Visible = !currSI.IsHeading || currSI.IsSummaryLine);
            lbDesc.Font = font;
            lbSellTotal.Font = font;
            //Indent to rep level of schedule item in treelist. Add extra level if summary
            float leftOS = Indent * ((currSI.Level ?? 0) + (currSI.IsSummaryLine ? 1 : 0));
            float sz = Math.Max(DescMaxWidth - leftOS, DescMaxWidth / 2);
            lbDesc.LeftF = leftOS + DescLeft;
            lbDesc.WidthF = sz;
        }
    }
}
