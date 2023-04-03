using Newtonsoft.Json;
using System;

namespace cpModel.Dtos.Lookup
{
    public class SurveyRequestLookupDto
    {
        public int SurveyId { get; set; }
        public int? SrNumber { get; set; }
        public DateTime? DateRequest { get; set; }
        public string Description { get; set; }

    }
}
