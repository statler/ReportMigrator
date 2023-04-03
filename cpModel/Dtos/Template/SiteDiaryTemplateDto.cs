using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class SiteDiaryTemplateDto
    {
        public int SiteDiaryId { get; set; }
        public int SiteDiaryNo { get; set; }
        public int? DiaryById { get; set; }
        public DateTime? DiaryDate { get; set; }
        public string Weather { get; set; }
        public DateTime? DateReviewed { get; set; }
        public string DiaryDateString => DiaryDate == null ? "" : DiaryDate.Value.ToShortDateString();
        public string DateReviewedString => DateReviewed == null ? "" : DateReviewed.Value.ToShortDateString();
        public int? ReviewedById { get; set; }

        public string DiaryByName { get; set; }
        public string ReviewedByName { get; set; }

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Atp_Notification, SiteDiaryId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;
        public string SiteDiaryLink => $@"<a href='{URL}'>Site Diary: {SiteDiaryNo}</a>";
        public string SiteDiaryLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";
    }
}
