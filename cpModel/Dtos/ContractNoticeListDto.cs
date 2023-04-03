using cpModel.Dtos;
using cpModel.Models;
using cpModel.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{

    public partial class ContractNoticeListDto 
    {
        public int ConId { get; set; }
        public string ConTemplateRef { get; set; }
        public string ConRef { get; set; }
        public DateTime? ConDate { get; set; }
        public DateTime? DateResponseRequired { get; set; }
        public string ConSubjectHtml { get; set; }
        public string ConSubjectPlainText { get; set; }
        Lazy<string> _subjectHtmlTemp_AsText;
        public string SubjectHtmlTemp_AsText => _subjectHtmlTemp_AsText.Value;
        public ContractNoticeListDto()
        {
            _subjectHtmlTemp_AsText = new Lazy<string>(GetTempSubjectAsHTML);
        }
        string subjectHtmlTemp;
        public string SubjectHtmlTemp { get => subjectHtmlTemp; set
            {
                if (subjectHtmlTemp == value) return;
                subjectHtmlTemp = value;
                _subjectHtmlTemp_AsText = new Lazy<string>(GetTempSubjectAsHTML);
            }
        }
        string GetTempSubjectAsHTML()
        {
            return SubjectHtmlTemp.GetPlainTextFromHTML();
        }

        public DateTime? CloseOutDate { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? ApproveToSendDate { get; set; }

        public int? RequestById { get; set; }
        public string RequestByName { get; set; }
        public int? RequestOnBehalfId { get; set; }
        public string RequestOnBehalfName { get; set; }

        public ICollection<CnToDto> CnTos { get; set; } = new List<CnToDto>();

        public int NumberOfResponses { get; set; }
        public int NumberOfActionedResponses { get; set; }

        public string Status => CloseOutDate==null ? "Open" : "Closed";
        public string NoticeToCsv => string.Join(", ", CnTos.Select(x => x.FullName).ToList());
    }

}
