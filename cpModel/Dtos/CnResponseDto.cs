using System;

namespace cpModel.Dtos
{
    public partial class CnResponseDto : CnResponseListDto
    {
        public DateTime? DateSent { get; set; }
        public string ResponseHtml { get; set; }
        public int? ActionRequiredById { get; set; }
        public DateTime? ActionRequiredDate { get; set; }
        public DateTime? DateActioned { get; set; }
        public int? ActionCompletedById { get; set; }
        public string ActionCommentHtml { get; set; }

        public string ActionRequiredByName { get; set; }
        public string ActionCompletedByName { get; set; }


    }

}
