using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class ForecastWLDistroDto 
    {
        public int ForecastWlDistroId { get; set; }
        public int? ForecastWinLossId { get; set; }
        public int? CostCodeId { get; set; }
        public decimal? PercDist { get; set; }
        public string CostCodeName { get; set; }
        public string CostCodeDescription { get; set; }
    }
}
