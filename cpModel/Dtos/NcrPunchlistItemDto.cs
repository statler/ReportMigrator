using System;

namespace cpModel.Dtos
{
    public class NcrPunchlistItemDto
    {
        public int NcrPunchlistItemId { get; set; }
        public int? NcrId { get; set; }
        public int? PunchlistItemId { get; set; }
        public int? PunchlistId { get; set; }

        public int? NcrNo { get; set; }
        public string NcrDesc { get; set; }
        public DateTime? NcrApprovalDate { get; set; }
        public DateTime? NcrCloseOutDate { get; set; }
        public bool NcrHasApproval => NcrApprovalDate != null;
        public bool NcrIsClosedOut => NcrCloseOutDate != null;
        public int? PunchlistNo { get; set; }
        public string PunchlistName { get; set; }
        public string PunchlistItemNo { get; set; }
        public string PunchlistNumDesc => $"{PunchlistItemNo}: {PunchlistNo} {PunchlistName} ";

    }
}
