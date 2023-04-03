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
    public partial class LotMapSectionBlock: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int LotMapSectionBlockId { get; set; }
        public int? LotMapSectionId { get; set; }
        public string Description { get; set; }
        public int? RefLotMapSectionId { get; set; }
        public int? LotMapLayerId { get; set; }
        public double? ChainageSt { get; set; }
        public double? ChainageEnd { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual LotMapLayer LotMapLayer { get; set; }
        public virtual LotMapSection LotMapSection_LotMapSectionId { get; set; }
        public virtual LotMapSection RefLotMapSection { get; set; }

        public LotMapSectionBlock()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
