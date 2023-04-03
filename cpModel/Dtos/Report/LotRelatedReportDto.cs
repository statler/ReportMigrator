
using cpModel.Enums;

namespace cpModel.Dtos.Report
{
    public class LotRelatedReportDto
    {
        public LotRelatedReportDto(LotRelationFullDto relatedLotRecord, bool IsPrimary)
        {
            LotId = IsPrimary ? relatedLotRecord.LotId1 : relatedLotRecord.LotId2;
            IsPrimaryMember = IsPrimary;
            LotNumber = IsPrimary ? relatedLotRecord.Lot2Number : relatedLotRecord.Lot1Number;
            LotDescription = IsPrimary ? relatedLotRecord.Lot2Description : relatedLotRecord.Lot1Description;
            Description = relatedLotRecord.Description;
            RelationshipType = relatedLotRecord.RelationshipType;
        }
        public int? LotId { get; set; }
        public bool IsPrimaryMember { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string Description { get; set; }
        public int? RelationshipType { get; set; }
        public LotRelationshipType? RelationshipTypeEnum => (LotRelationshipType?)RelationshipType;
        public string RelationshipTypeName => $"{GetRelationshipType()} {LotNumber}";

        string GetRelationshipType()
        {
            if (RelationshipTypeEnum != null)
            {
                switch (RelationshipTypeEnum.Value)
                {
                    case LotRelationshipType.Replacement:
                        if (IsPrimaryMember) return "Replaces";
                        else return "Replaced By";
                    case LotRelationshipType.Sublot:
                        if (IsPrimaryMember) return "Parent of";
                        else return "Child of";
                    case LotRelationshipType.Other:
                        return $"Other ({Description})";
                    case LotRelationshipType.Underlying:
                        if (IsPrimaryMember) return "Overlies";
                        else return "Underlies";
                }
            }

            return "unkown relationship to";
        }
    }
}
