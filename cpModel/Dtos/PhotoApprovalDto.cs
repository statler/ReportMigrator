using cpModel.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class PhotoApprovalDto
    {
        public int PhotoApprovalId { get; set; }
        public int? ApprovalId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public bool? InclAttach { get; set; }
        public int? ActionId { get; set; }
        public string PhotoDescription { get; set; }
        public string ApprovalDescription => $"{ApprovalNo}: {ApprovalSubjectPlainText}";
        public int? ApprovalNo { get; set; }

        [JsonIgnore]
        public string ApprovalSubjectHtml { get; set; }
        [JsonIgnore]
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
    }
}
