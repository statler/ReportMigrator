using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class ProjectReportDto
    {
        public int ProjectControlId { get; set; }
        public int? ProjectId { get; set; }
        public string Url { get; set; }
        public int? ReportType { get; set; }
        public byte[] ReportDefinition { get; set; }
        public bool? IsSubReport { get; set; }
        public int? MinReqDbVersion { get; set; }
        public string ReportBaseType { get; set; }
    }

}
