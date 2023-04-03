using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class TimeZoneDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StandardName { get; set; }
        public string BaseUtcOffset { get; set; }
    }
}
