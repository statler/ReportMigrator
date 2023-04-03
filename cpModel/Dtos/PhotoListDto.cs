using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class PhotoListDto
    {
        public int PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? SiteDiaryId { get; set; }
        public string Description { get; set; }
        public DateTime? PhotoDate { get; set; }
        public string PhotoImage { get; set; }
        public DateTime? PhotoDatePart { get; set; }
    }
}
