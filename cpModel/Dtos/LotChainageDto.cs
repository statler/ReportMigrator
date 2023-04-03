using cpModel.Dtos.Lookup;
using Newtonsoft.Json;
using System;

namespace cpModel.Dtos
{
    public class LotChainageDto : LotLookupDto
    {
        public int? ControlLineId { get; set; }
        public int? GeometryType { get; set; }
        public decimal? ChStart { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? ChEnd { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public string Rl1 { get; set; }
        public string Rl2 { get; set; }
    }
}
