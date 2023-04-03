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
    public partial class RiskTemplate: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int RiskTemplateId { get; set; }
        public int? ProjectId { get; set; }
        public string RiskTemplateName { get; set; }
        public int? AuthorId { get; set; }
        public DateTime? DateAuthored { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateLastReviewed { get; set; }
        public int? RevisionId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<RiskActivity> RiskActivities { get; set; }

        public virtual Project Project { get; set; }
        public virtual User ApprovedBy { get; set; }
        public virtual User Author { get; set; }

        public RiskTemplate()
        {
            RiskActivities = new HashSet<RiskActivity>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
