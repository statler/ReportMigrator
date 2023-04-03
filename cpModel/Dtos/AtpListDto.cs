using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class AtpListDto 
    {
        public int AtpId { get; set; }
        public int? AtpNo { get; set; }
        public string Description { get; set; }
        public int? RequestedById { get; set; }
        public int? SentToId { get; set; }
        public DateTime? DateRespRequired { get; set; }
        public DateTime? Datesub { get; set; }
        public DateTime? Timesub { get; set; }

        public string SentToName { get; set; }
        public string RequestedByName { get; set; }
        public bool IsApproved { get; set; }
    }
}
