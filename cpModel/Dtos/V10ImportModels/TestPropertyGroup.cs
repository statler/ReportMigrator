using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace cpModel.Models.V10ImportModels
{

    public partial class TestPropertyGroup
    {
        public int ProjectID { get; set; }
        public string TestPropertyGroupName { get; set; }
        public int TestPropertyGroupID { get; set; }
    }
}
