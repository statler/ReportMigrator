using cpModel.Helpers;
using cpModel.Interfaces;
using System;

namespace cpModel.Dtos
{
    public partial class CustomRegisterItemDto : EditableModelBase<CustomRegisterItemDto>, ILockableEntity, IOrderable
    {
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public int CustomRegisterItemId { get; set; }
        public int? CustomRegisterId { get; set; }
        public string CustomRegisterValue { get; set; }
        public string ShortCode { get; set; }
        public decimal? OrderId { get; set; }

    }
}
