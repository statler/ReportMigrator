using cpModel.Dtos.Report;
using cpModel.Models;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace cpReportDefinitions.PhotoRep
{
    public partial class rptPhoto : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Photo Report";

        public rptPhoto()
        {
            InitializeComponent();
            ReportTitle = "Photo Report";
            Detail.BeforePrint += Detail_BeforePrint;
            DataSourceRowChanged += RptPhoto_DataSourceRowChanged;
            img.Sizing = ImageSizeMode.ZoomImage;
        }

        private void RptPhoto_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            var currPhoto = GetCurrentRow() as PhotoReportDto;
            RecordReference = "Photo: " + currPhoto.PhotoNo;
        }



        public void Detail_BeforePrint(System.Object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as DetailBand).Report;
            if (r == null) return;

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
