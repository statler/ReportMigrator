using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Template
{
    public class PurchaseOrderSetTemplateDto: TemplateSetBaseDto
    {
        public List<PurchaseOrderTemplateDto> PurchaseOrders { get; set; }
    }
}
