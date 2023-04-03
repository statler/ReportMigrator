using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class SiteDiaryListDto
    {
        public int SiteDiaryId { get; set; }
        public int SiteDiaryNo { get; set; }
        public int? DiaryById { get; set; }
        public DateTime? DiaryDate { get; set; }
        public string SiteActivityHtml { get; set; }
        public string Weather { get; set; }
        public DateTime? DateReviewed { get; set; }
        public int? ReviewedById { get; set; }

        public string DiaryByName { get; set; }
        public string ReviewedByName { get; set; }
    }
}
