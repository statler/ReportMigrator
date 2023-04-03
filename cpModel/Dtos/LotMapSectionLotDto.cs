using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class LotMapSectionLotDto : ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int LotMapSectionLotId { get; set; }
        public int? LotMapSectionId { get; set; }
        public int? LotId { get; set; }
        public int? LotMapLayerId { get; set; }
        public double? ChainageSt { get; set; }
        public double? ChainageEnd { get; set; }
        public bool? IsExcluded { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public bool? IsManuallyIncluded { get; set; }
        public decimal? LayerOrderId { get; set; }
    }
}
