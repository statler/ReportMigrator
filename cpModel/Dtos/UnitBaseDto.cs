using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class UnitBaseDto : ILockableEntity
    {

        public int UnitId { get; set; }
        public int? ProjectId { get; set; }
        public string UnitName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }
    }
}
