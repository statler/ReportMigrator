using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class TestPropertyItemDto
    {
        public int TestPropertyItemId { get; set; }
        public int? TestPropertyGroupId { get; set; }
        public string TestPropertyName { get; set; }
        public string DefaultValue { get; set; }
        public decimal? OrderId { get; set; }
    }
}
