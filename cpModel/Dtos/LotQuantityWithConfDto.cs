using System;

namespace cpModel.Dtos
{
    public class LotQuantityWithConfDto : LotQuantityListDto
    {

        public decimal? PercComp { get; set; }
        public DateTime? LotDateConf { get; set; }
        public DateTime? LotDateGuar { get; set; }
        public bool? LotIsConformed => LotDateConf != null;
        public bool? LotIsGuaranteed => LotDateGuar != null;
        public bool? LotIsConformedOrGuaranteed => (LotIsConformed ?? false) || (LotIsGuaranteed ?? false);

        public string ScheduleNo { get; set; }
        public string ScheduleDescription { get; set; }
        public decimal? ScheduleSellRate { get; set; }
        public string ScheduleUnit { get; set; }
        public string SchedNumDescRateUnit
        {
            get
            {
                string rateString = "";
                if (ScheduleSellRate != null) rateString = string.Format("{0:C2}", ScheduleSellRate);
                if (ScheduleNo == null || ScheduleNo.Length == 0)
                {
                    return string.Format("{1} - {2} ({3})", ScheduleNo, ScheduleDescription, rateString, ScheduleUnit);
                }
                else
                {
                    return string.Format("{0}: {1} - {2} ({3})", ScheduleNo, ScheduleDescription, rateString, ScheduleUnit);
                }
            }
        }
        public string SchedNumDesc
        {
            get
            {
                if (ScheduleNo == null || ScheduleNo.Length == 0)
                {
                    return Description;
                }
                else
                {
                    return string.Format("{0}: {1}", ScheduleNo, Description);
                }
            }
        }


    }
}
