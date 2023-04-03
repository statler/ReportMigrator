using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Lookup
{
    public partial class LotMapLayerLookupDto 
    {
        public int LotMapLayerId { get; set; }
        public string Description { get; set; }
        public decimal? OrderId { get; set; }
    }
}
