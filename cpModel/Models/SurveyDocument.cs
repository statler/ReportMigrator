using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Models
{
    public partial class SurveyDocument : ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int SurveyDocumentId { get; set; }
        public int? SurveyId { get; set; }
        public int? DocumentId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }
        public virtual CpDocument CpDocument { get; set; }
        public virtual SurveyRequest SurveyRequest { get; set; }

        public SurveyDocument()
        {
            InitializePartial();
        }
        partial void InitializePartial();

    }
}
