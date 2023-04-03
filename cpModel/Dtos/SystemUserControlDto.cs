using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class SystemUserControlDto
    {
        public int UserControlId { get; set; }
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string FullName { get; set; }
    }
}
