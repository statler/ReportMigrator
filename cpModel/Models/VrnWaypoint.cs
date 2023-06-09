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
    public partial class VrnWaypoint: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int VrnWaypointId { get; set; }
        public int? VariationId { get; set; }
        public int? VrnStatusId { get; set; }
        public DateTime? WaypointDate { get; set; }
        public string Description { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual Variation Variation { get; set; }
        public virtual VrnStatus VrnStatus { get; set; }

        public VrnWaypoint()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

