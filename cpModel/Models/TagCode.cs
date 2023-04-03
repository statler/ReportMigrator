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
    public partial class TagCode: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public bool? IsPrimary { get; set; }
        public int? ProjectId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<LotTag> LotTags { get; set; }

        public virtual Project Project { get; set; }

        public TagCode()
        {
            Lots = new HashSet<Lot>();
            LotTags = new HashSet<LotTag>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
