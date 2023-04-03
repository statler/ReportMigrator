using Newtonsoft.Json;
using System;

namespace cpModel.Dtos.Lookup
{
    public partial class AtpLookupDto
    { 
        public int AtpId { get; set; }
        public int? AtpNo { get; set; }
        public DateTime? Datesub { get; set; }
        public string Description { get; set; }
        public string AtpNoDescription => $"{AtpNo}: {Description}";
    }
}
