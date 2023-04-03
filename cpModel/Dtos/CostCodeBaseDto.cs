using cpModel.Helpers;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class CostCodeBaseDto 
    {
        public int CostCodeId { get; set; }
        public string CostCodeName { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? BudgetQty { get; set; }
        public decimal? BudgetTotal { get; set; }
        public int? ProjectId { get; set; }
        public bool? UnitQty { get; set; }
        public bool? Inactive { get; set; }
    }
}
