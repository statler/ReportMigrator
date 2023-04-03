namespace cpModel.Dtos
{
    public class ItpScheduleDto
    {
        public int ItpSchedId { get; set; }
        public int? ItpId { get; set; }
        public int? ScheduleId { get; set; }

        public string ItpDocNo { get; set; }
        public string ItpDescription { get; set; }
        public string ScheduleNo { get; set; }
        public string ScheduleDesc { get; set; }
        public string SchedNumDesc
        {
            get
            {
                if (ScheduleNo == null || ScheduleNo.Length == 0)
                {
                    return ScheduleDesc;
                }
                else
                {
                    return string.Format("{0}: {1}", ScheduleNo, ScheduleDesc);
                }
            }
        }
    }
}