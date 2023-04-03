using System;

namespace cpModel.Dtos
{
    public class NcrLotDto
    {
        public int NcrLotId { get; set; }
        public int? NcrId { get; set; }
        public int? LotId { get; set; }

        public int? NcrNo { get; set; }
        public string NcrDesc { get; set; }
        public DateTime? NcrApprovalDate { get; set; }
        public DateTime? NcrCloseOutDate { get; set; }
        public bool NcrHasApproval => NcrApprovalDate != null;
        public bool NcrIsClosedOut => NcrCloseOutDate != null;
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }

    }
}
