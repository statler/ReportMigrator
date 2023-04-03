namespace cpModel.Dtos

{
    public partial class SurveyDocumentDto
    {
        public int SurveyDocumentId { get; set; }
        public int? SurveyId { get; set; }
        public int? DocumentId { get; set; }

        public int? SrNumber { get; set; }
        public string SurveyDesc { get; set; }
        public string DocNumber { get; set; }
        public string DocDescription { get; set; }

    }
}
