using System;

namespace cpModel.Dtos.Lookup
{
    public class ItpLookupDto
    {
        public int ItpId { get; set; }
        public string Description { get; set; }
        public string ItpDocnumber { get; set; }
        public DateTime? RevisionDate { get; set; }
    }
}
