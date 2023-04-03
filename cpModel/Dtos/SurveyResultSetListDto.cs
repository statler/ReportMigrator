using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Interfaces;
using cpModel.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cpModel.Dtos
{
    public class SurveyResultSetListDto
    {
        public int? SurveyRequestId { get; set; }
        public int SurveyResultSetId { get; set; }
        public string Description { get; set; }
        public int? SurveyById { get; set; }
        public DateTime? CreatedOn { get; set; }

        public DateTime? SurveyDate { get; set; }

    }
}
