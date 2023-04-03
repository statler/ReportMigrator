
using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using cpModel.Models;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class LotItpLookupDto 
    {
        public int LotItpId { get; set; }
        public int? LotId { get; set; }
        public int? ItpId { get; set; }
        public string Description { get; set; }

        public string LotNumber { get; set; }
        public string ItpName { get; set; }

    }
}
