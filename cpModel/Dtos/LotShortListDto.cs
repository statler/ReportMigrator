using System;

namespace cpModel.Dtos
{
    public partial class LotShortListDto
    {
        public int LotId { get; set; }
        public string LotNumber { get; set; }
        public int? ProjectId { get; set; }
        public int? AreaCodeId { get; set; }
        public int? WorkTypeId { get; set; }
        public string Description { get; set; }
        public int? RaisedById { get; set; }
        public int? ConformedById { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public int DaysOpen => DateOpen != null && DateGuar == null && DateConf == null ? (DateTime.Now - DateOpen.Value).Days : 0;

    }

}
