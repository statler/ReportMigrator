using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.CloneDto
{
    public class ItpDetailCloneDto
    {
        public int ItpDetailId { get; set; }
        public int? ItpId { get; set; }
        public decimal? ItemOrder { get; set; }
        public string ReferenceText { get; set; }
        public string Description { get; set; }
        public string AltQvctext { get; set; }
        public int? ItemType { get; set; }
        public int? Hpwpc { get; set; }
        public string Clause { get; set; }
        public bool? InspectRequired { get; set; }
        public bool? AuthorityRequired { get; set; }
        public bool? VerifyRequired { get; set; }
        public string InspMeth { get; set; }
        public string Records { get; set; }
        public string Responsibility { get; set; }
        public bool? ItpInc { get; set; }
        public bool? QvcInc { get; set; }
    }
}
