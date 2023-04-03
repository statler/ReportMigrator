using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public partial class ImageLayerPointDto 
    {
        public int ImageLayerPointId { get; set; }
        public int? ImageLayerId { get; set; }
        public int? PositionId { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public decimal? OrderId { get; set; }
    }
}
