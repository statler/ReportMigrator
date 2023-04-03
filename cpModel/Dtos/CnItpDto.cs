using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class CnItpDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnitpId { get; set; }
        public int? CnId { get; set; }
        public int? ItpId { get; set; }
        public bool? InclNotice { get; set; }

        public bool? InclAtt { get; set; }
        public string ConRef { get; set; }
        public string ItpDocNumber { get; set; }
        public string ItpName { get; set; }
        public string ItpDocNumberAndDescription => $"{ItpDocNumber} : {ItpName}";
    }

}
// </auto-generated>


