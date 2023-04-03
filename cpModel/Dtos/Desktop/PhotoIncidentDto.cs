
using cpModel.Helpers;
namespace cpModel.Dtos
{
    public partial class PhotoIncidentDto
    {
        public int PhotoIncidentId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? IncidentId { get; set; }
        public int? IncidentNo { get; set; }

        public string IncidentDescHtml { get; set; }
        public string PhotoDescription { get; set; }
        public string IncidentDescPlainText => IncidentDescHtml.GetPlainTextFromHTML();
    }

}
