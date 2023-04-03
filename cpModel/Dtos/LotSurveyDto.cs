using System;

namespace cpModel.Dtos
{
    public class LotSurveyDto
    {
        public int SurveyLotId { get; set; }
        public int? SurveyId { get; set; }
        public int? LotId { get; set; }

        public int? SrNumber { get; set; }
        public string SurveyDesc { get; set; }
        public DateTime? SurveyApprovalDate { get; set; }
        public DateTime? SurveyCloseOutDate { get; set; }
        public bool SurveyHasApproval => SurveyApprovalDate != null;
        public bool SurveyIsClosedOut => SurveyCloseOutDate != null;
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public int LotSurveyId => SurveyLotId;

    }
}
