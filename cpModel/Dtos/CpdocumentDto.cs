using System;

namespace cpModel.Dtos
{
    public partial class CpDocumentDto
    {
        public int DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public string DocGroup { get; set; }
        public string DocType { get; set; }
        public int? ProjectId { get; set; }
        public string ControlledBy { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? DateReceived { get; set; }
        
    }
}
