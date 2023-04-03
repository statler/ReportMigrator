
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public partial class LotItpReportDto : LotItpDto, IItpReportDto
    {
        public DateTime? DateLotOpened { get; set; }
        public DateTime? DateWorkStarted { get; set; }
        public DateTime? DateWorkEnded { get; set; }

        //Manually populated
        public List<LotItpDetailReportDto> lstLotItpDetails { get; set; }
        public List<LotItpLotQuantityReportDto> Quantities { get; set; }
        public List<UserBasicDto> UsersForTable { get; set; }


        public int RecordId => LotItpId;
        public string InstanceDescription => DescInclLot;

        public string QvcDocnumber { get => SourceQvcNo; set => SourceQvcNo = value; }

        public List<IItpDetailReportDto> lstDetails => lstLotItpDetails.Cast<IItpDetailReportDto>().ToList();
    }

}
