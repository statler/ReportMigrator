using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace cpModel.Dtos.Report
{
    public partial class IncidentReportDto : IncidentBaseDto
    {
        public string ApprovedByName { get; set; }
        public string ClosedOutName { get; set; }

        public List<IncidentPersonDto> lstPersons { get; set; }
        public List<string> dummyMidSection { get; set; }
    }
}
