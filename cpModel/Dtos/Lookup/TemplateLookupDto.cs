using cpModel.Enums;

namespace cpModel.Dtos.Lookup
{
    public partial class TemplateLookupDto
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int? TemplateTypeId { get; set; }
        public string TemplateTypeName => ((TemplateTypeEnum)TemplateTypeId).ToString().Replace("_", " ");

    }
}
