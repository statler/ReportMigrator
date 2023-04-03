
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using bm = cpModel.Models;

namespace cpModel.Models.V10ImportModels
{

    public partial class TestResultField
    {
        public int TestResultFieldID { get; set; }
        public int TestMethodID { get; set; }
        public decimal OrderID { get; set; }
        public int ResultFieldDataType { get; set; }
        public string ResultFieldName { get; set; }
        public string ResultUnit { get; set; }
        public string Formula { get; set; }



    }
}
