using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class CnNoticeDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnNoticeId { get; set; }
        public int? CnId1 { get; set; }
        public int? CnId2 { get; set; }
        public bool? InclNotice { get; set; }

        public bool? InclAtt { get; set; }

        public string ConRef1 { get; set; }
        public string ConSubject1 { get; set; }
        public string ConRef2 { get; set; }
        public string ConSubject2 { get; set; }

    }

}
