using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class SiteDiaryDto :SiteDiaryListDto
    {
        public decimal? HoursLost { get; set; }
        public decimal? PersonnelOnsite { get; set; }
        public decimal? HoursWorked { get; set; }
        public decimal? PersonnelOnsiteSubbies { get; set; }
        public decimal? HoursWorkedSubbies { get; set; }
        public string ReviewCommentsHtml { get; set; }
    }
}
