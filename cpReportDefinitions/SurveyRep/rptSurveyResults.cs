using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;
using System;

namespace cpReportDefinitions.SurveyRep
{
    public partial class rptSurveyResults : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Survey Results";
        SurveyResultSetsReportDto _currSurvey;
        public rptSurveyResults()
        {
            InitializeComponent();
            ReportTitle = "Survey Results";
            DataSourceRowChanged += rptSurvey_DataSourceRowChanged;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
        }
        private void rptSurvey_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currSurvey = GetCurrentRow() as SurveyResultSetsReportDto;
            RecordReference = "Survey: " + _currSurvey.SrNumber;
        }
        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _currSurvey = GetCurrentRow() as SurveyResultSetsReportDto;
            RecordReference = "Survey: " + _currSurvey.SrNumber;
        }
    }
}
