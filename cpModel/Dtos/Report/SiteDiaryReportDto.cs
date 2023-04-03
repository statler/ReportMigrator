using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Dtos.Report
{
    public class SiteDiaryReportDto : SiteDiaryDto
    {
        public List<InstructionDto> LstInstructions { get; set; }
        public List<IncidentReportDto> LstIncidents { get; set; }
        public List<SiteDiaryCostReportDto> LstDiaryCosts { get; set; }
        public List<PhotoReportDto> LstPhotos { get; set; }

        public List<CCSummary>  LstSdCostCodes => LstDiaryCosts.SelectMany(x => x.LstCcSummary.Value).ToList();
    }
}
