using cpModel.Helpers;

namespace cpModel.Dtos
{
    public partial class CnInstructionDto
    {
        public int CnInstructionId { get; set; }
        public int? CnId { get; set; }
        public int? InstructionId { get; set; }
        public int? InstructionNo { get; set; }
        private string instructionDesc;
        public string InstructionDesc
        {
            get => instructionDesc;
            set => instructionDesc = value.GetPlainTextFromHTML();
        }
        public bool? InclNotice { get; set; }
        public bool? InclAtt { get; set; }
        public string FullInstructionDesc => $"{InstructionNo}: {InstructionDesc}";
        public string ConRef { get; set; }
    }

}
// </auto-generated>


