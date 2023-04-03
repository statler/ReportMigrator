using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Helpers;

namespace cpModel.Dtos
{
    public partial class ContractNoticeTemplateDto 
    {       
        public int ConTempId { get; set; }
        public int? ProjectId { get; set; }
        public string Abbrev { get; set; }
        public string ConTempName { get; set; }
        public string ConTempSubjectHtml { get; set; }
        public string ConSubjectPlainText => ConTempSubjectHtml.GetPlainTextFromHTML();
        public string ConTemplateHtml { get; set; }
        public bool? RequiresResponse { get; set; }
        public bool? IsInactive { get; set; }
    }
}
