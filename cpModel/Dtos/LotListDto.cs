using System;
using System.Collections.Generic;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class LotListDto : LotShortListDto
    {
        public string LotStatus { get; set; }
        public DateTime? DateRejected { get; set; }
        public DateTime? DateWorkEnd { get; set; }
        public DateTime? DateWorkSt { get; set; }

        public decimal? EffPercentComplete { get; set; }
        public decimal? PercentComplete { get; set; }
        public string PrimaryTag { get; set; }
    }
}
