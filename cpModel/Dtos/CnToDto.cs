namespace cpModel.Dtos
{
    public class CnToDto
    {
        public int CnToId { get; set; }
        public int? NoticeId { get; set; }
        public string NoticeEmail { get; set; }
        public int? NoticeToId { get; set; }

        public string FullName { get; set; }
        public string EffectiveEmailAddress { get; set; }

    }
}
