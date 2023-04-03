using System.IO;
using cpModel.Helpers;

namespace cpModel.Dtos
{
    public partial class FsIncidentDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsIncidentId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? IncidentId { get; set; }
        public int? IncidentNo { get; set; }
        public decimal? OrderId { get; set; }

        private string incidentDesc;
        public string IncidentDesc
        {
            get => incidentDesc;
            set => incidentDesc = value.GetPlainTextFromHTML();
        }
        public string FullIncidentDesc => $"{IncidentNo}: {IncidentDesc}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => IncidentId;
        public string RelatedName => FullIncidentDesc;
    }
}
