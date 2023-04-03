using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class TestRequestTestBaseDto : ILockableEntity
    {
        public int TestRequestTestId { get; set; }
        public string SampleId { get; set; }
        public int? TestMethodId { get; set; }
        public int? TestRequestId { get; set; }
        public int? ScheduleId { get; set; }
        public DateTime? DateSampled { get; set; }
        public int? ControlLineId { get; set; }
        public decimal? Xref { get; set; }
        public decimal? Yref { get; set; }
        public decimal? Zref { get; set; }
        public bool? ManualOverride { get; set; }
        public string Notes { get; set; }
        public bool? TestComplete { get; set; }
        public string ComplianceReq { get; set; }
        public string TestMethodName { get; set; }
        public int? TestRequestNo { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }
        public string ControlLineName { get; set; }
        public string ScheduleName { get; set; }

        //Used for AddTests
        public int? NoOfTests { get; set; }

        public decimal? TestCost { get; set; }
        public decimal? TestRev { get; set; }
        public int? TestBillingStatusId { get; set; }
    }

}
