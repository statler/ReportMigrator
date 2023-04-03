using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.DocRep.ContractNotices
{
    public partial class rptContractNotice
    {
        public override string BaseReportName { get; set; } = "Contract Notice";
        public rptContractNotice()
        {
            InitializeComponent();
            ReportTitle = "Contract Notice";
            BeforePrint += rpt_BeforePrint;
            Detail.BeforePrint += Detail_BeforePrint;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            rtSubject.BeforePrint += rtSubject_BeforePrint;
            rtRequestDetails.BeforePrint += rtRequestDetails_BeforePrint;
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currCn = GetCurrentRow() as ContractNoticeReportDto;
        }

        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currCn = GetCurrentRow() as ContractNoticeReportDto;
            RecordReference = "Notice: " + _currCn.ConRef;
        }

        private void rpt_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataSource is IEnumerable<ContractNoticeReportDto> lstCn)
            {
                if (lstCn != null)
                {
                    foreach (var cn in lstCn)
                    {
                        bool isDraft = cn.ApproveToSendDate == null;
                        if (isDraft) IsInternalReport = true;
                    }
                }
            }
        }

        private void rtSubject_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            rtSubject.Html = GetHtmlWithDefaultFormat(_report, "ConSubjectHtml", rtSubject.Font);
        }

        private void rtRequestDetails_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            rtRequestDetails.Html = GetHtmlWithDefaultFormat(_report, "ConHtml", rtRequestDetails.Font);
        }
    }
}