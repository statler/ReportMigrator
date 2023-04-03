using Newtonsoft.Json;
using System;

namespace cpModel.Dtos.Lookup
{
    public class TestRequestLookupDto
    { 
        public int TestRequestId { get; set; }
        public int? TestRequestNo { get; set; }
        public DateTime? DateRequest { get; set; }
        public string Description { get; set; }
        public string TRNoDescription => $"{TestRequestNo}: {Description}";
    }
}
