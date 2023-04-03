using System;

namespace cpModel.Dtos
{
    public partial class LotDto : LotListDto
    {

        public DateTime? DateClosed { get; set; }
        public int? ControlLineId { get; set; }
        public decimal? ChStart { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? ChEnd { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public string Rl1 { get; set; }
        public string Rl2 { get; set; }
        public decimal? NominalThickness { get; set; }
        public bool? IsAdvLocnDef { get; set; }
        public bool? TestRed { get; set; }
        public decimal? LotArea { get; set; }
        public decimal? LotLength { get; set; }
        public decimal? LotVolume { get; set; }
        public bool? IsAvlOverride { get; set; }
        public string Notes { get; set; }
        public int? GeometryType { get; set; }

        public string ControlLineName { get; set; }
        public string RaisedByName { get; set; }

        public string GeometryPropertyString
        {
            get
            {
                switch (GeometryType)
                {
                    case 1:
                        return "No Geometry";
                    case 2:
                        return "Chainage";
                    case 3:
                        return "Coord. Position";
                    case 4:
                        return "Coord. Region";
                    default:
                        return "Not Defined";
                }
            }
        }

        public int? PrimaryTagId { get; set; }
    }

}
