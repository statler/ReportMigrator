using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class WorkflowLogDto : WorkflowLogListDto, ILockableEntity
    {
        public string LogCommentHtml { get; set; }

        public int? OptimisticLockField { get; set; }
    }

}
