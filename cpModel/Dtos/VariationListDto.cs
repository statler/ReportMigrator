using System;

namespace cpModel.Dtos
{
    public class VariationListDto
    {
        public int VariationId { get; set; }
        public int? ProjectId { get; set; }
        public string VariationNo { get; set; }
        public string Description { get; set; }
        public decimal? SellTotalSubmitted { get; set; }
        public decimal? SellTotalApproved { get; set; }
        public string RaisedByName { get; set; }
        public decimal? QtyEstimated { get; set; }
        public DateTime? StatusDate { get; set; }
        public string VariationStatus { get; set; }
        public bool HasEstimate { get; set; }
        public decimal SellTotalEstimate { get; set; }
    }
}
