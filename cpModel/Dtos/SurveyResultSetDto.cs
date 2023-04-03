using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class SurveyResultSetDto
    {
        public int SurveyResultSetId { get; set; }
        public int? SurveyRequestId { get; set; }
        public string Description { get; set; }
        public DateTime? SurveyDate { get; set; }
        public int? SurveyById { get; set; }

        public int? SrNumber { get; set; }
        public string SurveyDesc { get; set; }
        public string FullSurveyDesc => SrNumber == null ? "" : $"{SrNumber}: {SurveyDesc}";
        public string SurveyResultSetDescription => $"{SurveyResultSetId}: {Description}";

    }
}
