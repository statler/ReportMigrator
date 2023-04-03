using System;
using System.IO;

namespace cpModel.Dtos
{
    public partial class FsSurveyDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsSurveyId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? SurveyId { get; set; }
        public decimal? OrderId { get; set; }

        public int? SrNumber { get; set; }
        public string SurveyDesc { get; set; }
        public string FullSurveyDesc => SrNumber == null ? "" : $"{SrNumber}: {SurveyDesc}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }
        public DateTime? FileDate { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";
        public string Extension => Path.GetExtension(Filename);
        public int? RelatedId => SurveyId;
        public string RelatedName => FullSurveyDesc;

    }
}
