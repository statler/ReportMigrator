using cpModel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class ApprovalPunchlistItemDto
    {
        public int ApprovalPunchlistItemId { get; set; }
        public int? ApprovalId { get; set; }
        public int? PunchlistItemId { get; set; }
        public int? PunchlistId { get; set; }

        public int? PunchlistNo { get; set; }
        public string PunchlistName { get; set; }
        public string PunchlistItemNo { get; set; }
        public string PunchlistNumDesc => $"{PunchlistItemNo}: {PunchlistNo} {PunchlistName} ";
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        string ApprovalSubjectAsText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public string ApprovalNumDescription => $"{ApprovalNo.ToString()}: {ApprovalSubjectAsText}";
    }

}
