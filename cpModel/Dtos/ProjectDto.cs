using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string ContractNumber { get; set; }
        public bool? InActive { get; set; }
        public bool? IsRepository { get; set; }
        public string ProjectNumberAndName { get; set; }
        public int? SubscriberId { get; set; }
        public DateTime? ProjectEnd { get; set; }
        public DateTime? ProjectStart { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
