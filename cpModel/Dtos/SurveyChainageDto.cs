using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class SurveyChainageDto
    {
        public int SurveyChainageId { get; set; }
        public int? SurveyId { get; set; }
        public int? PositionTypeId { get; set; }
        public decimal? Chainage { get; set; }
        public decimal? LeftOs { get; set; }
        public decimal? RightOs { get; set; }
        public decimal? Rl { get; set; }
        public int? ControlLineId { get; set; }

    }
}
