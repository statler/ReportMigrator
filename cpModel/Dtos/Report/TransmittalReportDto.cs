using cpModel.Dtos.Template;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cpModel.Dtos.Report
{
    public partial class TransmittalReportDto : TransmittalBaseDto
    {
        public UserAddresseeTemplateDto TransmittalToInfo { get; set; }
        public List<TransmittalItemReportDto> lstTransmittalItems { get; set; }
    }

}
