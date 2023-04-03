using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Lookup
{
    public partial class CustomRegisterItemLookupDto
    {
        public int CustomRegisterItemId { get; set; }
        public int? CustomRegisterId { get; set; }
        public string CustomRegisterValue { get; set; }

    }
}
