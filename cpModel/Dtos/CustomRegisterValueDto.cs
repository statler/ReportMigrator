using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;

namespace cpModel.Dtos
{
    public partial class CustomRegisterValueDto
    {
        public int CustomRegisterValueId { get; set; }
        public int? RegisterId { get; set; }
        public int? RegisterItemId { get; set; }
        public int? CustomRegisterId { get; set; }
        public int? CustomRegisterItemId { get; set; }
        public int? RequiresText { get; set; }
        public string CrTextValue { get; set; }
        public string CrItemText { get; set; }
        public int? ValueTypeId { get; set; }
        public decimal? OrderId { get; set; }
        public CustomRegisterValueTypeEnum? ValueTypeEnum
        {
            get => ((CustomRegisterValueTypeEnum?)ValueTypeId) ?? CustomRegisterValueTypeEnum.Lookup;
            set => ValueTypeId = (int?)value;
        }

        public string EffValueText => ValueTypeEnum == CustomRegisterValueTypeEnum.Lookup ? CrItemText : CrTextValue;


    }
}
