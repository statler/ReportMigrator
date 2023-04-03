using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class SurveyCompleteDto
    {
        public DateTime DateComplete { get; set; }
        public int CompleteById { get; set; }
        public string Commentary { get; set; }
    }
}
