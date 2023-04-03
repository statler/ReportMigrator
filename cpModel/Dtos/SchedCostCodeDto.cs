namespace cpModel.Dtos
{
    public class SchedCostCodeDto
    {
        public int SchedCostCodeId { get; set; }
        public int? ScheduleId { get; set; }
        public int? CostcodeId { get; set; }
        public decimal? DistPercent { get; set; }
        public string CostCodeName { get; set; }
        public string CostCodeDescription { get; set; }
        public bool? ExclQty { get; set; }
        public string ScheduleNo { get; set; }
        public string ScheduleDescription { get; set; }
        public string ScheduleFullDescription
        {
            get
            {
                if (string.IsNullOrEmpty(ScheduleNo)) return ScheduleDescription;
                else return $"{ScheduleNo}: {ScheduleDescription}";
            }
        }
    }
}
