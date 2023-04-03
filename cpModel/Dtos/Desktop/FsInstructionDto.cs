using System.IO;
using cpModel.Helpers;

namespace cpModel.Dtos
{
    public partial class FsInstructionDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsInstructionId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? InstructionId { get; set; }
        public int? InstructionNo { get; set; }
        private string instructionDescription;
        public string InstructionDescription
        {
            get => instructionDescription;
            set => instructionDescription = value.GetPlainTextFromHTML();
        }
        public decimal? OrderId { get; set; }

        public string FullInstructionDesc => $"{InstructionNo}: {InstructionDescription}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => InstructionId;
        public string RelatedName => FullInstructionDesc;
    }
}
