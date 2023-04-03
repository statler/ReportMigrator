using cpModel.Enums;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class LotMapLayerDto : ILockableEntity
    {
        public int LotMapLayerId { get; set; }
        public int? LotMapSectionId { get; set; }
        public int? WorkTypeId { get; set; }
        public int? CustomRegisterItemId { get; set; }
        public decimal? OrderId { get; set; }
        public int? DisplayHeightDefault { get; set; }
        public double? ActualHeightDefault { get; set; }
        public double? OverlapTolerance { get; set; }
        public string Description { get; set; }
        public int? IsAndOr { get; set; }
        public FilterOperationEnum? IsAndOrEnum { get => IsAndOr == null ? null : (FilterOperationEnum?)IsAndOr; set => IsAndOr = (int)value; }
        public double? DepthFromTopLayer { get; set; }
        public int? OverlapBehaviour { get; set; }
        public LotMapStackOptionEnum? OverlapBehaviourEnum { get => OverlapBehaviour == null ? null : (LotMapStackOptionEnum?)OverlapBehaviour; set => OverlapBehaviour = (int)value; }
        public double? LabelFontHeight { get; set; }

        public string IsAndOrString => IsAndOrEnum?.ToString().Replace("_", " ");

        public string OverlapBehaviourString => OverlapBehaviourEnum?.ToString().Replace("_", " ");
        public double? MaxExageration { get; set; }

        public string WorkTypeName { get; set; }
        public string CustomRegisterItemName { get; set; }

        public int? OptimisticLockField { get; set; }
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }

}
