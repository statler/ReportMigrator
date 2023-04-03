using System;
using System.Collections.Generic;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class RevisionDto
    {
        public int RevisionId { get; set; }
        public int? DocumentId { get; set; }
        public string Description { get; set; }
        public string RevRef { get; set; }
        public DateTime? RevisionDate { get; set; }
        public DateTime? DateReceived { get; set; }
        public string EntityRevised { get; set; }
        

        public CpDocumentDto CpDocument { get; set; }
    }
}
