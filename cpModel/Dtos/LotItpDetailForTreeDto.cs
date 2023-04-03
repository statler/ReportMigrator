using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using cpShared.Extensions;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class LotItpDetailForTreeDto
    {
        public int LotItpDetailId { get; set; }
        public decimal? OrderId { get; set; }
        public int? LotItpId { get; set; }
        public int? ItpDetailId { get; set; }
        public string ReferenceText { get; set; }
        public string LotNumber { get; set; }
        public string ItpName { get; set; }
        public string ReferenceTextPlain => TextFunctions.ConvertRTFOrHTML(ReferenceText);
    }

}
