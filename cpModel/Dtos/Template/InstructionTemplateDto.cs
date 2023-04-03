using System;

namespace cpModel.Dtos.Template
{
    public class InstructionTemplateDto
    {
        public int InstructionId { get; set; }
        public int InstructionNo { get; set; }
        public DateTime? InstructionDate { get; set; }
        public string InstructionDateAsString => InstructionDate?.ToShortDateString() ?? "";
        public string DescriptionHtml { get; set; }
        public string InstructionToName { get; set; }
        public string InstructionByName { get; set; }
    }
}
