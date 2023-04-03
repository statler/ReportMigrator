

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using bm = cpModel.Models;

namespace cpModel.Models.V10ImportModels
{

    public partial class TestPropertyItem
    {
        public int TestPropertyItemID { get; set; }
        public int TestPropertyGroupID { get; set; }
        public string TestPropertyName { get; set; }
        public string DefaultValue { get; set; }
        public decimal OrderID { get; set; }

        
    }
}
