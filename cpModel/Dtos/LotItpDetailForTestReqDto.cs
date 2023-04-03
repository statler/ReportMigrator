using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class LotItpDetailForTestReqDto
    {
        public string Description { get; set; }
        public string SpecRef { get; set; }
        public List<string> Tests { get; set; }
    }
}
