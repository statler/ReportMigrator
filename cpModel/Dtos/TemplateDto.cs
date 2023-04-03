using cpModel.Enums;

namespace cpModel.Dtos
{
    public partial class TemplateDto
    {
        public int TemplateId { get; set; }
        public int? ProjectId { get; set; }
        public string TemplateName { get; set; }
        public string SubjectHtml { get; set; }
        public string BodyHtml { get; set; }
        public int? TemplateTypeId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsInActive { get; set; }

        public string TemplateTypeName => ((TemplateTypeEnum)TemplateTypeId).ToString().Replace("_", " ");

    }
}
