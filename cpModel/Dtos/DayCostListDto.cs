using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class DayCostListDto
    {
        public int DayCostId { get; set; }
        public DateTime? DateCost { get; set; }
        public string SupplierName { get; set; }
        public string ResourceName { get; set; }
    }
}
