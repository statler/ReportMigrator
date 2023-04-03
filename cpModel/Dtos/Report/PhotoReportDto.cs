using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public partial class PhotoReportDto : PhotoDto
    {
        public List<PhotoLotReportDto> Lots { get; set; }
        public List<PhotoNcrDto> Ncrs { get; set; }
        public List<PhotoVariationDto> Variations { get; set; }

    }
}
