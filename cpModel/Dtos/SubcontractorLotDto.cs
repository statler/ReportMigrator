using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class SubcontractorLotDto
    { 
        public int SubcontractorLotId { get; set; }
        public int? SubcontractorId { get; set; }
        public int? LotId { get; set; }
        public string LotNumber { get; set; }
        public string SubcontractorName { get; set; }
    }
}
