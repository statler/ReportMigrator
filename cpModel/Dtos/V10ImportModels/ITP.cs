using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using bm = cpModel.Models;
namespace cpModel.Models.V10ImportModels
{

    public partial class ITP
    {
        public int ITPID { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public string QVCDocnumber { get; set; }
        public string ITPDocnumber { get; set; }
        public int PersonControl { get; set; }
        public DateTime RevisionDate { get; set; }
        public int RevisionID { get; set; }
        public string SpecRef { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovalComment { get; set; }

        
    }

}
