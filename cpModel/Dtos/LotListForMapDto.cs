using System;
using System.Collections.Generic;
using cpModel.Interfaces;
using cpModel.Models;
using cpModel.Models.NonEf;

namespace cpModel.Dtos
{
    public class LotListForMapDto : LotListForMapShortDto, ILotDates, ICloneable
    {
        public int? WorkTypeId { get; set; }
        public string Description { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateRejected { get; set; }
        public DateTime? DateWorkSt { get; set; }

        public int? ControlLineId { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public decimal? NominalThickness { get; set; }

        public decimal? EffPercentComplete { get; set; }
        public decimal? PercentComplete { get; set; }
        public LotStatus LotStatusEnum => LotSummaryInfo.GetStatus(this);

        public LotMapLayerForLayoutDto Layer { get; set; }
        public double LeftCoord { get; set; }
        public double RightCoord { get; set; }
        public double Width => RightCoord - LeftCoord;

        public void SetCoords(double SectionSt, double SectionEnd, double Scale)
        {
            var ChStart0 = ChStart ?? 0;
            var ChEnd0 = ChEnd ?? 0;
            LeftCoord = Math.Max((double)ChStart0 - SectionSt, 0) * Scale;
            RightCoord = Math.Min((double)ChEnd0 - SectionSt, SectionEnd) * Scale;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
