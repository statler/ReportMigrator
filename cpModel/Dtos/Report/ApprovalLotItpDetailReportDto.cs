using cpModel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Report
{
    public partial class ApprovalLotItpDetailReportDto
    {
        public int? ApprovalId { get; set; }
        public int? LotItpDetailId { get; set; }
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public DateTime RequestDate { get; set; }
        public DateTime DateLastStep { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; }
    }
}
