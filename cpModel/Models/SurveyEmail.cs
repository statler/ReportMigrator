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
    public partial class SurveyEmail: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int SurveyEmailId { get; set; }
        public int? SurveyRequestId { get; set; }
        public int? EmailLogId { get; set; }
        public int? NotificationType { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual EmailLog EmailLog { get; set; }
        public virtual SurveyRequest SurveyRequest { get; set; }

        public SurveyEmail()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

