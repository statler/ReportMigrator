using System;

namespace cpModel.Dtos
{
    public partial class LotListForMapShortDto
    {
        public string LotNumber { get; set; }
        public int LotId { get; set; }
        public decimal? ChStart { get; set; }
        public decimal? ChEnd { get; set; }

    }

}
