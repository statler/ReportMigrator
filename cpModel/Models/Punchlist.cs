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
    public partial class Punchlist: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int PunchlistId { get; set; }
        public int? PunchlistNo { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? DateRaised { get; set; }
        public string Description { get; set; }
        public int? RaisedById { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? DatePublished { get; set; }
        public int? PublishedById { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<PunchlistItem> PunchlistItems { get; set; }
        public virtual ICollection<PunchlistUser> PunchlistUsers { get; set; }

        public virtual Project Project { get; set; }
        public virtual User ApprovedBy { get; set; }
        public virtual User PublishedBy { get; set; }
        public virtual User RaisedBy { get; set; }

        public Punchlist()
        {
            PunchlistItems = new HashSet<PunchlistItem>();
            PunchlistUsers = new HashSet<PunchlistUser>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

