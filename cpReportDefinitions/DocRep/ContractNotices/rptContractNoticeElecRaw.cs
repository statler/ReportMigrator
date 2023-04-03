using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using cpModel.Dtos;
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.DocRep.ContractNotices
{
    public partial class rptContractNoticeElecRaw
    {
        public override string BaseReportName { get; set; } = "Contract Notice (Elec) - Raw";
        public rptContractNoticeElecRaw()
        {
            InitializeComponent();
            ReportTitle = "Contract Notice";
            BeforePrint += rpt_BeforePrint;
            Detail.BeforePrint += Detail_BeforePrint;
            DetailReport.BeforePrint += DetailReport_BeforePrint;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            rtRequestDetails.BeforePrint += rtRequestDetails_BeforePrint;
            rtResponseDetail.BeforePrint += RtResponseDetail_BeforePrint;
            rtResponseDetailWithAction.BeforePrint += RtResponseDetail_BeforePrint;
            sbResponseNoAction.BeforePrint += SbResponse_BeforePrint;
            sbResponseWithAction.BeforePrint += SbResponse_BeforePrint;
        }

        private void SbResponse_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase responseReport = (sender as SubBand).Band.Report;
            var response = responseReport.GetCurrentRow() as CnResponseDto;
            var hasActionInfo = response?.ActionRequiredById != null || response?.ActionCompletedById != null;
            if (sender == sbResponseNoAction) e.Cancel = hasActionInfo;
            if (sender == sbResponseWithAction) e.Cancel = !hasActionInfo;
        }

        private void RtResponseDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase responseReport = (sender as XRRichText).Band.Report;
            (sender as XRRichText).Html = GetHtmlWithDefaultFormat(responseReport, "ResponseHtml", (sender as XRRichText).Font);
        }

        private void DetailReport_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            XtraReportBase responseReport = (sender as DetailReportBand).Report;
            var _currCn = responseReport.GetCurrentRow() as ContractNoticeReportDto;
            if (_currCn.Responses.Count > 0) e.Cancel = false;
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

        private void rtRequestDetails_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            rtRequestDetails.Html = GetHtmlWithDefaultFormat(_report, "ConHtml", rtRequestDetails.Font);
        }
    }
}
