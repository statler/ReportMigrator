using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using bm = cpModel.Models;

namespace cpModel.Models.V10ImportModels
{

    public partial class TestMethod
    {
        public int TestMethodID { get; set; }
        public string TestNum { get; set; }
        public int ProjectID { get; set; }
        public string TestDescription { get; set; }

        
    }
}
