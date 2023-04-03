using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class ImageLayerDto 
    {
        public int ImageLayerId { get; set; }
        public string LayerName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public double? Opacity { get; set; }
        public double? Rotation { get; set; }
        public bool? IsVisible { get; set; }
        public DateTime? LayerDate { get; set; }
        //public bool? IsDefault { get; set; }
        public bool? IsDisabled { get; set; }
        public decimal? OrderId { get; set; }
        public int? FileStoreId { get; set; }
    }
}
