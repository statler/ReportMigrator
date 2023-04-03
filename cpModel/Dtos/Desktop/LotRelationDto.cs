using cpModel.Enums;

namespace cpModel.Dtos
{
    public partial class LotRelationDto
    {

        public int? LotId1 { get; set; }
        public int? RelationshipType { get; set; }
        public int RelLotId { get; set; }
        public int? LotId2 { get; set; }
        public string Description { get; set; }

        public string Lot1Number { get; set; }
        public string Lot2Number { get; set; }
        public LotRelationshipType? RelationshipTypeEnum => (LotRelationshipType?)RelationshipType;
    }
}
