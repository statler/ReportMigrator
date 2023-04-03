using cpModel.Models;
using System;
using System.Collections.Generic;

namespace cpModel.Dtos
{
    public class LotWithCalcPropsDto
    {
        public int LotId { get; set; }
        public string LotNumber { get; set; }
        public int? ProjectId { get; set; }
        public int? AreaCodeId { get; set; }
        public int? WorkTypeId { get; set; }
        public string Description { get; set; }
        public int? RaisedById { get; set; }
        public int? ConformedById { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateWorkEnd { get; set; }
        public DateTime? DateWorkSt { get; set; }
        public decimal? PercentComplete { get; set; }
        public int? ControlLineId { get; set; }
        public string ControlLineString { get; set; }
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
        public DateTime? DateRejected { get; set; }
        public int? GeometryType { get; set; }
        public int? PrimaryTagId { get; set; }
        public string LotStatus { get; set; }
        public int NCRCount { get; set; }
        public int ATPCount { get; set; }
        public int TRCount { get; set; }
        public int FsDocCount { get; set; }
        public int NCRCountUnapp { get; set; }
        public int ATPCountUnapp { get; set; }
        public int TRCountIncomp { get; set; }
        public decimal EffValue { get; set; }
        public decimal LotValue { get; set; }
        public decimal RPValue { get; set; }

        public decimal? EffPercentComplete { get; set; }
    }
}
