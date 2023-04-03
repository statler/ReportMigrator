using System;

namespace cpModel.Dtos.Template
{
    public class PhotoTemplateDto
    {
        public int PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public string Description { get; set; }
        public DateTime? PhotoDate { get; set; }
        public string PhotoDateAsString => PhotoDate?.ToShortDateString() ?? "";
        public string PhotoNoAndDescription => $"{PhotoNo}: {Description}";

    }
}
