using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class WorkTypeDto
    {
        public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set; }
        public string Description { get; set; }
        public bool HasScheduleLink { get; set; }
        public string FirstLetter { get; set; }
    }
}
