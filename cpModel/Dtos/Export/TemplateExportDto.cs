using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpModel.Dtos.Export
{
    public class TemplateExportDto
    {
        public int TemplateId { get; set; }
        public int? ProjectId { get; set; }
        public string TemplateName { get; set; }
        public string SubjectHtml { get; set; }
        public string BodyHtml { get; set; }
        public int? TemplateTypeId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsInActive { get; set; }
    }
}
