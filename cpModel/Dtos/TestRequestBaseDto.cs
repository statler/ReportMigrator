using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class TestRequestBaseDto : TestRequestListDto,  ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Source { get; set; }
        public decimal? DepthToTest { get; set; }
        public bool? IsAdvLocnDef { get; set; }
        public int? ControlLineId { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public string LevelDatum { get; set; }
        public int? LocateMethod { get; set; }
        public string Notes { get; set; }
        public bool? IsAvlOverride { get; set; }
        public decimal? TestLength { get; set; }
        public decimal? TestArea { get; set; }
        public decimal? TestVolume { get; set; }
        public DateTime? TimeReqd { get; set; }
        public int? TestType { get; set; }
        
        public int? ReferenceSystemTypeId { get; set; }

        public bool AllApproved { get; set; }
        public int? ProjectId { get; set; }


    }
}
