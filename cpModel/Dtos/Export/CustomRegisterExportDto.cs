using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpModel.Dtos.Export
{
    public partial class CustomRegisterExportDto
    {
        public string CustomRegisterName { get; set; }
        public string ShortCode { get; set; }
        public bool? IsRequired { get; set; }

        public List<CustomRegisterItemExportDto> CustomRegisterItems { get; set; }
    }
}
