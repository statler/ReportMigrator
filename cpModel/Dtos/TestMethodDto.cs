using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class TestMethodDto
    {
        public int TestMethodId { get; set; }
        public string TestNum { get; set; }
        public string TestDescription { get; set; }

        public string FirstLetter { get; set; }
    }
}
