using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class CnVariationDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnVariationId { get; set; }
        public int? CnId { get; set; }
        public int? VariationId { get; set; }
        public bool? InclNotice { get; set; }


        public bool? InclAtt { get; set; }
        public string ConRef { get; set; }
        public string VariationNo { get; set; }
        public string VariationDesc { get; set; }
        public string FullVrnDesc => $"{VariationNo}: {VariationDesc}";


    }

}
// </auto-generated>


