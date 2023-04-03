using cpModel.Dtos.Report;
using cpShared.Extensions;
using DevExpress.XtraReports.UI;
using System;

namespace cpReportDefinitions.SurveyRep
{
    public partial class rptSurveyRequest : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Survey Request";
        SurveyReportDto _currSurvey;

        public rptSurveyRequest()
        {
            InitializeComponent();
            ReportTitle = "Survey Request";
            xrDetail.BeforePrint += (s, e) => RichEditInBand_Master_BeforePrint(s, e, "Detail");
            DataSourceRowChanged += rptSurvey_DataSourceRowChanged;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            sbDetail.BeforePrint += SbDetail_BeforePrint;
            sbTolerance.BeforePrint += SbTolerance_BeforePrint;
            sbComplete.BeforePrint += SbComplete_BeforePrint;
        }

        private void SbComplete_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase responseReport = (sender as SubBand).Band.Report;
            var _currSurvey = responseReport.GetCurrentRow() as SurveyReportDto;
            e.Cancel = _currSurvey.DateCompleted == null;
        }

        private void SbTolerance_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase responseReport = (sender as SubBand).Band.Report;
            var _currSurvey = responseReport.GetCurrentRow() as SurveyReportDto;
            e.Cancel = _currSurvey.ToleranceAbove == null && _currSurvey.ToleranceAbove == null && _currSurvey.ToleranceThickness == null && string.IsNullOrWhiteSpace(_currSurvey.ToleranceCommentary);
        }

        private void SbDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase responseReport = (sender as SubBand).Band.Report;
            var _currSurvey = responseReport.GetCurrentRow() as SurveyReportDto;
            e.Cancel = string.IsNullOrWhiteSpace(TextFunctions.ConvertRTFOrHTML(_currSurvey.Detail));
        }

        private void rptSurvey_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currSurvey = GetCurrentRow() as SurveyReportDto;
            RecordReference = "Survey: " + _currSurvey.SrNumber;
        }
        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _currSurvey = GetCurrentRow() as SurveyReportDto;
            RecordReference = "Survey: " + _currSurvey.SrNumber;
        }

    }
}
