using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class SurveyEmailDto
    {
        public int SurveyEmailId { get; set; }
        public int? SurveyRequestId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public DateTime? EmailDate { get; set; }

        public int? SrNumber { get; set; }
        public DateTime DateRequest { get; set; }
        public string SurveyDescription { get; set; }
        public string EmailDescription => $"{EmailLogNo}: ({EmailDate:d})";
    }
}
