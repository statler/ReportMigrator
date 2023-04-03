namespace cpModel.Dtos
{
    public class WorkScheduleDto
    {
        public int WorkScheduleId { get; set; }
        public int? WorkId { get; set; }
        public int? ScheduleId { get; set; }

        public string WorkTypeName { get; set; }
        public string WorkTypeDescription { get; set; }
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