using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;

namespace cpModel.Dtos
{
    public partial class CustomRegisterDto : EditableModelBase<CustomRegisterDto>, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int CustomRegisterId { get; set; }
        public int? ProjectId { get; set; }
        public string CustomRegisterName { get; set; }
        public string ShortCode { get; set; }

        public bool IsActive { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReported { get; set; }
        public int? ValueTypeId { get; set; }
        public decimal? OrderId { get; set; }
        public CustomRegisterValueTypeEnum? ValueTypeEnum
        {
            get => ((CustomRegisterValueTypeEnum?)ValueTypeId) ?? CustomRegisterValueTypeEnum.Lookup;
            set => ValueTypeId = (int?)value;
        }
        public string FirstLetter { get; set; }
    }
}
