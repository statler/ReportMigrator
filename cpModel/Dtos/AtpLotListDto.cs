using System;

namespace cpModel.Dtos
{
    public partial class AtpLotListDto
    {
        public int AtpLotId { get; set; }
        public int? AtpId { get; set; }
        public int? LotId { get; set; }
        public string ItemInspect { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateInspect { get; set; }

        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public int? AtpNo { get; set; }
        public string AtpDescription { get; set; }
    }
}
