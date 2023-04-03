using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class LotItpForTestReqDto
    {
        public int LotItpId { get; set; }
        public string Description { get; set; }
        public string SpecRef { get; set; }
        public List<LotItpDetailForTestReqDto> Tests { get; set; }
    }
}
