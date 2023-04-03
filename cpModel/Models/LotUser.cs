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
    public partial class LotUser: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int? UserId { get; set; }
        public int? LotId { get; set; }
        public int? FunctionId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }
        public int LotUserId { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual User User { get; set; }

        public LotUser()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

