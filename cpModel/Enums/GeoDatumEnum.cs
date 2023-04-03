using System;
using System.ComponentModel;
using System.Linq;

namespace cpModel.Enums
{
    public enum GeoDatumEnum
    {
        // https://www.icsm.gov.au/australian-datums-and-how-move-between-them
        // https://www.icsm.gov.au/upgrades-australian-geospatial-reference-system
        [Description("Lat/Long (decimal)")]
        LatLong_dec = 1,
        GDA2020 = 2,
        GDA94 = 3
    }
}
