using System;

namespace cpModel.Dtos
{
    public partial class VrnWaypointDto
    {

        public int VrnWaypointId { get; set; }
        public int? VariationId { get; set; }
        public int? VrnStatusId { get; set; }
        public DateTime? WaypointDate { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }

    }
}
