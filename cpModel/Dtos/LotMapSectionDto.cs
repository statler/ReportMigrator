using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class LotMapSectionDto : ILockableEntity
    {
        public int LotMapSectionId { get; set; }
        public int? ProjectId { get; set; }
        public string Description { get; set; }
        public int? ControlLineId { get; set; }
        public double? ChStart { get; set; }
        public double? ChEnd { get; set; }
        public decimal? OrderId { get; set; }
        public double? ChainageIntervals { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public double? FontSize { get; set; }
        public double? LeftMargin { get; set; }
        public int? CustomRegisterId { get; set; }
        public bool? IsManuallyGenerated { get; set; }

        public string ControlLineName { get; set; }
        public string CustomRegisterName { get; set; }


        public int? OptimisticLockField { get; set; }
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
