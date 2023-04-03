using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Common
{
    public class ClaimOptionsInfo
    {
        public bool AddNewItems { get; set; }
        public bool UpdateItems { get; set; }
        public bool DeleteItems { get; set; }
        public ClaimQtyCalcEnum ToDateUpdateOption { get; set; }
        public bool UpdateRates { get; set; } = false;

        public ClaimOptionsInfo()
        {
        }
    }
}
