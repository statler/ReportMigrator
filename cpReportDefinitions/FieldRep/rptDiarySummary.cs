using System;
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.FieldRep
{
    public partial class rptDiarySummary
    {
        public override string BaseReportName { get; set; } = "Site Diary";
        public rptDiarySummary()
        {
            InitializeComponent();
            ReportTitle = "INTERNAL Site Activity Summary";
            DetailPhoto_Detail.BeforePrint += DetailPhoto_Detail_BeforePrint;
        }
        private void DetailPhoto_Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as DetailBand).Report;

            try
            {
                PhotoReportDto np = (PhotoReportDto)r.GetCurrentRow();
                if (np != null)
                {
                    GetPhotoById(img, np.PhotoId);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
