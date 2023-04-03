using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpModel.Dtos.Export
{
    public class ProjectReportExportDto
    {
        public int? ProjectId { get; set; }
        public string Url { get; set; }
        public int? ReportType { get; set; }
        public byte[] ReportDefinition { get; set; }
        public bool? IsSubReport { get; set; }
        public int? MinReqDbVersion { get; set; }
        public string ReportBaseType { get; set; }
    }
}
