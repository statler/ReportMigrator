using Newtonsoft.Json;
using System;

namespace cpModel.Dtos.Lookup
{
    public partial class VrnLookupDto 
    {
        public int VariationId { get; set; }
        public int? VariationNo { get; set; }
        public DateTime? DateRaised { get; set; }
        public string Description { get; set; }
    }

}
