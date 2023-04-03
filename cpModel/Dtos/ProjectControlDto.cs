using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class ProjectControlDto
    {
        public int ProjectControlId { get; set; }
        public int? ProjectId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
