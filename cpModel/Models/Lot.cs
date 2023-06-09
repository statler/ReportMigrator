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
    public partial class Lot: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int LotId { get; set; }
        public string LotNumber { get; set; }
        public int? ProjectId { get; set; }
        public int? AreaCodeId { get; set; }
        public int? WorkTypeId { get; set; }
        public string Description { get; set; }
        public int? RaisedById { get; set; }
        public int? ConformedById { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateWorkEnd { get; set; }
        public DateTime? DateWorkSt { get; set; }
        public decimal? PercentComplete { get; set; }
        public int? ControlLineId { get; set; }
        public decimal? ChStart { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? ChEnd { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public string Rl1 { get; set; }
        public string Rl2 { get; set; }
        public decimal? NominalThickness { get; set; }
        public bool? IsAdvLocnDef { get; set; }
        public bool? TestRed { get; set; }
        public decimal? LotArea { get; set; }
        public decimal? LotLength { get; set; }
        public decimal? LotVolume { get; set; }
        public bool? IsAvlOverride { get; set; }
        public string Notes { get; set; }
        public DateTime? DateRejected { get; set; }
        public int? GeometryType { get; set; }
        public int? PrimaryTagId { get; set; }
        public int? ReferenceSystemTypeId { get; set; }
        public int? Priority { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ApprovalLot> ApprovalLots { get; set; }
        public virtual ICollection<AtpLot> AtpLots { get; set; }
        public virtual ICollection<CnLot> CnLots { get; set; }
        public virtual ICollection<FsLot> FsLots { get; set; }
        public virtual ICollection<LotCoordinate> LotCoordinates { get; set; }
        public virtual ICollection<LotCustomRegItem> LotCustomRegItems { get; set; }
        public virtual ICollection<LotInstruction> LotInstructions { get; set; }
        public virtual ICollection<LotItp> LotItps { get; set; }
        public virtual ICollection<LotItpDetail> LotItpDetails { get; set; }
        public virtual ICollection<LotMapSectionLot> LotMapSectionLots { get; set; }
        public virtual ICollection<LotPunchlistItem> LotPunchlistItems { get; set; }
        public virtual ICollection<LotQuantity> LotQuantities { get; set; }
        public virtual ICollection<LotRelation> LotRelations_LotId1 { get; set; }
        public virtual ICollection<LotRelation> LotRelations_LotId2 { get; set; }
        public virtual ICollection<LotSurvey> LotSurveys { get; set; }
        public virtual ICollection<LotSurveyResultSet> LotSurveyResultSets { get; set; }
        public virtual ICollection<LotTag> LotTags { get; set; }
        public virtual ICollection<LotUser> LotUsers { get; set; }
        public virtual ICollection<NcrLot> NcrLots { get; set; }
        public virtual ICollection<PhotoLot> PhotoLots { get; set; }
        public virtual ICollection<ProgressClaimSnapshot> ProgressClaimSnapshots { get; set; }
        public virtual ICollection<SubcontractorLot> SubcontractorLots { get; set; }
        public virtual ICollection<TestRequest> TestRequests { get; set; }
        public virtual ICollection<TestSchedule> TestSchedules { get; set; }
        public virtual ICollection<VariationLot> VariationLots { get; set; }

        public virtual AreaCode AreaCode { get; set; }
        public virtual ControlLine ControlLine { get; set; }
        public virtual Project Project { get; set; }
        public virtual TagCode TagCode { get; set; }
        public virtual User ConformedBy { get; set; }
        public virtual User RaisedBy { get; set; }
        public virtual WorkType WorkType { get; set; }

        public Lot()
        {
            ApprovalLots = new HashSet<ApprovalLot>();
            AtpLots = new HashSet<AtpLot>();
            CnLots = new HashSet<CnLot>();
            FsLots = new HashSet<FsLot>();
            LotCoordinates = new HashSet<LotCoordinate>();
            LotCustomRegItems = new HashSet<LotCustomRegItem>();
            LotInstructions = new HashSet<LotInstruction>();
            LotItps = new HashSet<LotItp>();
            LotItpDetails = new HashSet<LotItpDetail>();
            LotMapSectionLots = new HashSet<LotMapSectionLot>();
            LotPunchlistItems = new HashSet<LotPunchlistItem>();
            LotQuantities = new HashSet<LotQuantity>();
            LotRelations_LotId1 = new HashSet<LotRelation>();
            LotRelations_LotId2 = new HashSet<LotRelation>();
            LotSurveys = new HashSet<LotSurvey>();
            LotSurveyResultSets = new HashSet<LotSurveyResultSet>();
            LotTags = new HashSet<LotTag>();
            LotUsers = new HashSet<LotUser>();
            NcrLots = new HashSet<NcrLot>();
            PhotoLots = new HashSet<PhotoLot>();
            ProgressClaimSnapshots = new HashSet<ProgressClaimSnapshot>();
            SubcontractorLots = new HashSet<SubcontractorLot>();
            TestRequests = new HashSet<TestRequest>();
            TestSchedules = new HashSet<TestSchedule>();
            VariationLots = new HashSet<VariationLot>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

