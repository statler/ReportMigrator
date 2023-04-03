using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class IncidentPersonDto 
    {
        public int IncidentPersonId { get; set; }
        public int? IncidentId { get; set; }
        public int? IncidentNo { get; set; }
        public int? ContactId { get; set; }
        public bool? IsWitness { get; set; }

        public string ContactName { get; set; }
        public string ContactCompany { get; set; }
    }
}
