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
    public partial class ControlLine: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ControlLineId { get; set; }
        public string ControlLineName { get; set; }
        public int? ProjectId { get; set; }
        public string Description { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ControlLinePoint> ControlLinePoints { get; set; }
        public virtual ICollection<ControlLineTranslation> ControlLineTranslations_ControlLineParentId { get; set; }
        public virtual ICollection<ControlLineTranslation> ControlLineTranslations_ControlLineReferenceId { get; set; }
        public virtual ICollection<FsControlLine> FsControlLines { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<LotCoordinate> LotCoordinates { get; set; }
        public virtual ICollection<LotMapSection> LotMapSections { get; set; }
        public virtual ICollection<PunchlistItemPoint> PunchlistItemPoints { get; set; }
        public virtual ICollection<SurveyChainage> SurveyChainages { get; set; }
        public virtual ICollection<SurveyCoordinate> SurveyCoordinates { get; set; }
        public virtual ICollection<TestCoordinate> TestCoordinates { get; set; }
        public virtual ICollection<TestRequest> TestRequests { get; set; }
        public virtual ICollection<TestRequestTest> TestRequestTests { get; set; }

        public virtual Project Project { get; set; }

        public ControlLine()
        {
            ControlLinePoints = new HashSet<ControlLinePoint>();
            ControlLineTranslations_ControlLineParentId = new HashSet<ControlLineTranslation>();
            ControlLineTranslations_ControlLineReferenceId = new HashSet<ControlLineTranslation>();
            FsControlLines = new HashSet<FsControlLine>();
            Lots = new HashSet<Lot>();
            LotCoordinates = new HashSet<LotCoordinate>();
            LotMapSections = new HashSet<LotMapSection>();
            PunchlistItemPoints = new HashSet<PunchlistItemPoint>();
            SurveyChainages = new HashSet<SurveyChainage>();
            SurveyCoordinates = new HashSet<SurveyCoordinate>();
            TestCoordinates = new HashSet<TestCoordinate>();
            TestRequests = new HashSet<TestRequest>();
            TestRequestTests = new HashSet<TestRequestTest>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

