using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class LotUserDto
    { 
        public int LotUserId { get; set; }
        public int? UserId { get; set; }
        public int? LotId { get; set; }
        public int? FunctionId { get; set; }
        public string LotNumber { get; set; }
        public string UserFullName { get; set; }

    }
}
