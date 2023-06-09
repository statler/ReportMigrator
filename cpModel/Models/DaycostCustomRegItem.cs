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
    public partial class DaycostCustomRegItem: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int DaycostCustomRegItemId { get; set; }
        public int? DaycostId { get; set; }
        public int? CustomRegisterItemId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual CustomRegisterItem CustomRegisterItem { get; set; }
        public virtual DayCost DayCost { get; set; }

        public DaycostCustomRegItem()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

