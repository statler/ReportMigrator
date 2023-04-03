using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class SurveyResultListDto
    {
        public int SurveyResultId { get; set; }
        public int? SurveyResultSetId { get; set; }
        public decimal? Xcoord { get; set; }
        public decimal? Ycoord { get; set; }
        public decimal? Zcoord { get; set; }
        public double? Zdesign { get; set; }
        public bool? IsNonCompliant { get; set; }
        public string Comment { get; set; }

    }
}
