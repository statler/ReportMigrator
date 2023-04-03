using System;
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.FieldRep
{
    public partial class rptIncident
    {
        public override string BaseReportName { get; set; } = "Incident Report";
        public rptIncident()
        {
            InitializeComponent();
            dummyMid.BeforePrint += DummyMid_BeforePrint;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            reDescription.BeforePrint += ReDescription_BeforePrint;
            sbApproval.BeforePrint += SbApproval_BeforePrint;
            sbCloseout.BeforePrint += SbCloseout_BeforePrint;
        }
        
        private void SbCloseout_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as Band).Report;
            IncidentReportDto i = (IncidentReportDto)r?.GetCurrentRow();
            if (i.CloseOutDate == null) e.Cancel = true;
        }

        private void SbApproval_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as Band).Report;
            IncidentReportDto i = (IncidentReportDto)r?.GetCurrentRow();
            if (i.ApprovedDate == null) e.Cancel = true;
        }

        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currInc = GetCurrentRow() as IncidentReportDto;
            if (_currInc!=null) RecordReference = "Incident: " + _currInc.IncidentNo;
        }

        private void DummyMid_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as Band).Report;
            IncidentReportDto l = (IncidentReportDto)r?.GetCurrentRow();
            if (l == null) return;
            reDescription.Html = l.DescriptionHtml;
            reActions.Html = l.ActionsHtml;
            reReoccurrence.Html = l.ActionsPreventReoccurrenceHtml;
            reCause.Html = l.CauseIncidentHtml;
            reCloseout.Html = l.CloseOutCommentsHtml;
            reApproval.Html = l.ApprovedCommentsHtml;
        }

        private void ReDescription_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
