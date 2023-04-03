using System;
using System.Collections.Generic;
using System.IO;

namespace cpModel.Dtos.Report
{
    public class SurveyResultSetReportDto : SurveyResultSetDto
    {
        public string ShortDesc
        {
            get
            {
                string resultDesc = SurveyResultSetId.ToString();
                if (Description != null)
                    using (var reader = new StringReader(Description))
                    {
                        resultDesc += ": " + reader.ReadLine();
                    }
                return resultDesc;
            }
        }
        public List<SurveyResultReportDto> lstResults { get; set; }
    }
}
