using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class InstructionBaseDto : InstructionListDto, ILockableEntity
    {
        public int? ProjectId { get; set; }
        public int? SiteDiaryId { get; set; }
        public int? ClosedOutById { get; set; }
        public string CloseOutComments { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }
    }
}
