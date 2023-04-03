using Newtonsoft.Json;
using System;

namespace cpModel.Dtos.Lookup
{
    public partial class NcrLookupDto 
    { 
        public int NcrId { get; set; }
        public int? NcrNo { get; set; }
        public DateTime? DateRaised { get; set; }
        public string Description { get; set; }
    }

}
