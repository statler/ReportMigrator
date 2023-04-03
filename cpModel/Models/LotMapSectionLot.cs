// <auto-generated>
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Models
{
    public partial class LotMapSectionLot: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int LotMapSectionLotId { get; set; }
        public int? LotMapSectionId { get; set; }
        public int? LotId { get; set; }
        public int? LotMapLayerId { get; set; }
        public double? ChainageSt { get; set; }
        public double? ChainageEnd { get; set; }
        public bool? IsExcluded { get; set; }
        public bool? IsManuallyIncluded { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual LotMapLayer LotMapLayer { get; set; }
        public virtual LotMapSection LotMapSection { get; set; }

        public LotMapSectionLot()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
