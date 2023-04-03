using cpModel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class VrnInstructionDto
    { 
        public int VrnInstructionId { get; set; }
        public int? InstructionId { get; set; }
        public int? InstructionNo { get; set; }
        public int? VariationId { get; set; }

        public string VrnNumber { get; set; }
        public string VrnDesc { get; set; }
        public string InstructionDescHtml { get; set; }
        public string InstructionDescPlain => RichEditServer.GetPlainTextFromHTML(InstructionDescHtml);
    }
}
