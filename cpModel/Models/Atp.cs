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
    public partial class Atp: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int AtpId { get; set; }
        public int? AtpNo { get; set; }
        public string Description { get; set; }
        public int? ProjectId { get; set; }
        public int? RequestedById { get; set; }
        public int? SentToId { get; set; }
        public DateTime? DateRespRequired { get; set; }
        public DateTime? Datesub { get; set; }
        public DateTime? Timesub { get; set; }
        public string AtpNumSuffix { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<AtpLot> AtpLots { get; set; }
        public virtual ICollection<FsAtp> FsAtps { get; set; }
        public virtual ICollection<LotItpDetail> LotItpDetails { get; set; }

        public virtual Project Project { get; set; }
        public virtual User RequestedBy { get; set; }
        public virtual User SentTo { get; set; }

        public Atp()
        {
            AtpLots = new HashSet<AtpLot>();
            FsAtps = new HashSet<FsAtp>();
            LotItpDetails = new HashSet<LotItpDetail>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

