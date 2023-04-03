using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public partial class ItpReportDto : ItpDto, IItpReportDto
    {
        public string InstanceDescription => $"{ItpDocnumber}: {Description}";
        public DateTime? DateLotOpened { get; set; }
        public DateTime? DateWorkStarted { get; set; }
        public DateTime? DateWorkEnded { get; set; }

        //Manually populated
        public List<ItpDetailReportDto> lstItpDetails { get; set; }

        public int RecordId => ItpId;

        public List<IItpDetailReportDto> lstDetails => lstItpDetails.Cast<IItpDetailReportDto>().ToList();
    }

}
