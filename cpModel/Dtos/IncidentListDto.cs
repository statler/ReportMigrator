using System;

namespace cpModel.Dtos
{
    public partial class IncidentListDto
    {
        public int IncidentId { get; set; }
        public int IncidentNo { get; set; }
        public int? IncidentTypeId { get; set; }
        public DateTime? IncidentDate { get; set; }
        public string DescriptionHtml { get; set; }
        public int? RaisedById { get; set; }
        public string RaisedByName { get; set; }
    }
}
