
using cpModel.Helpers;
using System;

namespace cpModel.Dtos
{
    public class LotInstructionDto
    {
        public int LotInstructionId { get; set; }
        public int? LotId { get; set; }
        public int? InstructionId { get; set; }
        public int? InstructionNo { get; set; }

        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string InstructionDescriptionHtml { get; set; }
        public DateTime? InstructionDate { get; set; }

        public string InstructionDescriptionPlainText => InstructionDescriptionHtml.GetPlainTextFromHTML();
        public string InstructionNoDate => $"{InstructionNo}: {InstructionDate:d}";
    }
}
