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
    public partial class Template: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int TemplateId { get; set; }
        public int? SubscriberId { get; set; }
        public int? ProjectId { get; set; }
        public string TemplateName { get; set; }
        public string SubjectHtml { get; set; }
        public string BodyHtml { get; set; }
        public int? TemplateTypeId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsInActive { get; set; }
        public int? VersionIx { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual Project Project { get; set; }
        public virtual Subscriber Subscriber { get; set; }

        public Template()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

