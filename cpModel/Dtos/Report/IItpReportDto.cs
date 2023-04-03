using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public interface IItpReportDto
    {
        int RecordId { get; }
        string InstanceDescription { get; }
        DateTime? DateLotOpened { get; set; }
        DateTime? DateWorkStarted { get; set; }
        DateTime? DateWorkEnded { get; set; }

        //Manually populated
        List<IItpDetailReportDto> lstDetails { get; }

        string Description { get; set; }
        string QvcDocnumber { get; set; }
        System.DateTime? RevisionDate { get; set; }
        int? RevisionId { get; set; }
    }
}
