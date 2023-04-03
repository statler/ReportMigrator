using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class LotItpTestForTestReq
    {
            public int LotItpTestId { get; set; }
            public int? TestMethodId { get; set; }
            public decimal? FreqNorm { get; set; }
            public decimal? FreqRed { get; set; }
            public decimal? FreqLotNorm { get; set; }
            public decimal? FreqLotRed { get; set; }
            public string Unit { get; set; }
            public int? QuantityBasis { get; set; }
            public string Compliance { get; set; }
            public bool? IsOptional { get; set; }
            public bool? IsDefault { get; set; }
    }
}
