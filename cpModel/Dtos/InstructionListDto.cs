using System;
using System.Collections.Generic;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class InstructionListDto
    {
        public int InstructionId { get; set; }
        public int InstructionNo { get; set; }
        public bool? IsInstructionGiven { get; set; }
        public DateTime? InstructionDate { get; set; }
        public string DescriptionHtml { get; set; }
        public int? InstructionToId { get; set; }
        public int? InstructionById { get; set; }
        public DateTime? ClosedOutDate { get; set; }

        public string InstructionToName { get; set; }
        public string InstructionByName { get; set; }
    }
}
