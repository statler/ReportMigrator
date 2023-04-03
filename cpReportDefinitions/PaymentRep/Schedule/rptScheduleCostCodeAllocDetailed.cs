using cpModel.Dtos.Report;
using System;
using System.Drawing;
using System.Linq;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptScheduleCostCodeAllocDetailed : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Cost Code Allocations - Detailed";

        public bool DoFormat;
        const float _descLeft = 0F;
        const float _descMaxWidth = 1585F;
        const float _indent = 50F;


        public rptScheduleCostCodeAllocDetailed()
        {
            InitializeComponent();
            IsInternalReport = true;
            ReportTitle = "Cost Code Allocations - Detailed";
            Detail.BeforePrint += Detail_BeforePrint;
            Detail_CC.BeforePrint += Detail_CC_BeforePrint;
        }


        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currSI = GetCurrentRow() as ScheduleFlatReportDto;
            this.lbAlloc.Visible = !((_currSI.IsSummaryLine || (_currSI.IsTotalled ?? false)) && _currSI.Ccs.Sum(x => x.DistPercent ?? 0) == 0);

            Font font = new Font(lbSchedDesc.Font, FontStyle.Regular);
            if (_currSI.IsHeading || _currSI.IsSummaryLine)
            {
                if (_currSI.Level == 0) font = new Font(font, FontStyle.Bold);
                if (_currSI.Level == 1) font = new Font(font, FontStyle.Underline);
            }
            if (_currSI.IsSummaryLine)
            {
                font = new Font(font, font.Style | FontStyle.Italic);
            }
            lbSchedDesc.Font = font;
            //Indent to rep level of schedule item in treelist. Add extra level if summary
            float leftOS = _indent * ((_currSI.Level ?? 0) + (_currSI.IsSummaryLine ? 1 : 0));
            float sz = Math.Max(_descMaxWidth - leftOS, _descMaxWidth / 2);
            lbSchedDesc.LeftF = leftOS + _descLeft;
            lbSchedDesc.WidthF = sz;
        }

        private void Detail_CC_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currSI = GetCurrentRow() as ScheduleFlatReportDto;
            e.Cancel = !(_currSI != null && _currSI.Ccs.Count > 0);

        }
    }
}
