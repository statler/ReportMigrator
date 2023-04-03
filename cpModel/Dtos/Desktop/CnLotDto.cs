
using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class CnLotDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnLotId { get; set; }
        public int? CnId { get; set; }
        public int? LotId { get; set; }
        public bool? InclNotice { get; set; }

        public bool? InclAtt { get; set; }

        public string ConRef { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
    }

}
