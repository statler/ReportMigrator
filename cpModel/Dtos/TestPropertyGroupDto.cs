using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class TestPropertyGroupDto
    {
        public int? ProjectId { get; set; }
        public string TestPropertyGroupName { get; set; }
        public int TestPropertyGroupId { get; set; }

        public string FirstLetter { get; set; }
    }
}
