using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class ControlLinePointDto 
    {
        public int ControlLinePointId { get; set; }
        public int? ControlLineId { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public decimal? Z { get; set; }
        public decimal? Chainage { get; set; }
        public decimal? OrderId { get; set; }
    }
}
