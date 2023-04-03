using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class AreaCodeDto 
    {
        public int AreaCodeId { get; set; }
        public string AreaCodeName { get; set; }
        public string Description { get; set; }
        public string FirstLetter { get; set; }

    }
}
