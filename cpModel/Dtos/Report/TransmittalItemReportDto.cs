using cpModel.Dtos.Template;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cpModel.Dtos.Report
{
    public partial class TransmittalItemReportDto : TransmittalItemDto
    {
        public UserAddresseeTemplateDto TransmittalToInfo { get; set; }
        public List<TransmittalItemDto> lstTransmittalItems { get; set; }
        public string RevisionDescription { get; set; }
        public DateTime? RevisionDate { get; set; }
    }

}
