using System.Collections.Generic;

namespace cpModel.Dtos
{
    public partial class ApprovalDto : ApprovalListExtDto
    {
        public int? ProjectId { get; set; }
        public string BodyHtml { get; set; }

        public string CloseOutCommentHtml { get; set; }
        public string DirectlyApprovedCommentHtml { get; set; }
        public int? CloseOutNcrId { get; set; }
        public int? CloseOutApprId { get; set; }

        //Necessary to override JSON ignore on base
        new public ICollection<ApprovalToDto> ApprovalTos => base.ApprovalTos;
        new public ICollection<ApprovalCcDto> ApprovalCcs => base.ApprovalCcs;
    }

}
