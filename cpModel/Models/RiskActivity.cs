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
    public partial class RiskActivity: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int RiskActivityId { get; set; }
        public int? RiskTemplateId { get; set; }
        public string ActivityName { get; set; }
        public decimal? OrderId { get; set; }
        public int? ProjectId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<RiskActivityStep> RiskActivitySteps { get; set; }

        public virtual Project Project { get; set; }
        public virtual RiskTemplate RiskTemplate { get; set; }

        public RiskActivity()
        {
            RiskActivitySteps = new HashSet<RiskActivityStep>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

