using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace cpModel.Models.V10ImportModels
{

    public partial class ContractNoticeTemplate
    {
        public int ProjectID { get; set; }
        public int ConTempId { get; set; }
        public string Abbrev { get; set; }
        public string ConTempName { get; set; }
        public string ConTempSubjectHTML { get; set; }
        public string ConTemplateHTML { get; set; }
        public bool RequiresResponse { get; set; }
        public bool isInactive { get; set; }
    }
}
