using Newtonsoft.Json;
using System;

namespace cpModel.Dtos.Lookup
{
    public class LotLookupDto
    { 
        public int LotId { get; set; }
        public string LotNumber { get; set; }
        public string Description { get; set; }
        public DateTime? DateOpen { get; set; }
    }
}
