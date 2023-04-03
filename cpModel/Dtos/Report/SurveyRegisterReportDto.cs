using System;
using System.Collections.Generic;
using System.IO;
using cpModel.Enums;

namespace cpModel.Dtos.Report
{
    public class SurveyRegisterReportDto : SurveyRequestDto
    {
        public List<LotBasicReportDto> lstLots { get; set; }
        public string ShortDesc
        {
            get
            {
                if (Description == null) return null;
                using (var reader = new StringReader(Description))
                {
                    return reader.ReadLine();
                }
            }
        }
        public string SurveyTypeDesc => SurveyTypeId == null ? "" : Enum.GetName(typeof(SurveyTypeEnum), SurveyTypeId);
    }
}
