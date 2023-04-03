namespace cpModel.Dtos
{
    public partial class NcrDocumentDto
    {
        public int NcrDocumentId { get; set; }
        public int? NcrId { get; set; }
        public int? DocumentId { get; set; }

        public int? NcrNo { get; set; }
        public string NcrDesc { get; set; }
        public string DocNumber { get; set; }
        public string DocDescription { get; set; }

    }
}
