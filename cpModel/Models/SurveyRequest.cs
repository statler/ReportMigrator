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
    public partial class SurveyRequest: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int SurveyId { get; set; }
        public int? SrNumber { get; set; }
        public string SrNumberSuffix { get; set; }
        public int? ProjectId { get; set; }
        public int? RequestById { get; set; }
        public DateTime? DateRequest { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime? DateReqd { get; set; }
        public int? RequestToId { get; set; }
        public int? SurveyTypeId { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int? MarkedCompletedBy { get; set; }
        public string CompletionComment { get; set; }
        public double? ToleranceAbove { get; set; }
        public double? ToleranceBelow { get; set; }
        public double? ToleranceThickness { get; set; }
        public string ToleranceCommentary { get; set; }
        public int? GeometryTypeId { get; set; }
        public int? SurveyStatusId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ApprovalSurvey> ApprovalSurveys { get; set; }
        public virtual ICollection<FsSurvey> FsSurveys { get; set; }
        public virtual ICollection<LotSurvey> LotSurveys { get; set; }
        public virtual ICollection<SurveyChainage> SurveyChainages { get; set; }
        public virtual ICollection<SurveyCoordinate> SurveyCoordinates { get; set; }
        public virtual ICollection<SurveyEmail> SurveyEmails { get; set; }
        public virtual ICollection<SurveyResultSet> SurveyResultSets { get; set; }

        public virtual Project Project { get; set; }
        public virtual User RequestBy { get; set; }
        public virtual User RequestTo { get; set; }
        public virtual User User_MarkedCompletedBy { get; set; }

        public SurveyRequest()
        {
            ApprovalSurveys = new HashSet<ApprovalSurvey>();
            FsSurveys = new HashSet<FsSurvey>();
            LotSurveys = new HashSet<LotSurvey>();
            SurveyChainages = new HashSet<SurveyChainage>();
            SurveyCoordinates = new HashSet<SurveyCoordinate>();
            SurveyEmails = new HashSet<SurveyEmail>();
            SurveyResultSets = new HashSet<SurveyResultSet>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

