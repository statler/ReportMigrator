using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class TestCoordinateDto
    {
        public int TestCoordinatesId { get; set; }
        public decimal? OrderId { get; set; }
        public int? TestRequestId { get; set; }
        public decimal? Xcoord { get; set; }
        public decimal? Ycoord { get; set; }
        public decimal? Zcoord { get; set; }
    }
}
