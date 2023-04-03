using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class LotMapSectionForLayoutDto : LotMapSectionDto
    {
        public List<LotMapLayerForLayoutDto> LstLayers { get; set; }
    }
}
