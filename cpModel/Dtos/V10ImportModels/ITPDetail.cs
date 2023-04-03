using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using bm = cpModel.Models;
namespace cpModel.Models.V10ImportModels
{

    public partial class ITPDetail
    {
        public int ITPDetailID { get; set; }
        public int ITPID { get; set; }
        public decimal ItemOrder { get; set; }
        public string ReferenceText { get; set; }
        public string Description { get; set; }
        public string AltQVCText { get; set; }
        public int? ItemType { get; set; }
        public int? HPWPC { get; set; }
        public string Clause { get; set; }
        public bool InspectRequired { get; set; }
        public bool AuthorityRequired { get; set; }
        public bool VerifyRequired { get; set; }
        public string InspMeth { get; set; }
        public string Records { get; set; }
        public string Responsibility { get; set; }
        public bool ITPInc { get; set; }
        public bool QVCInc { get; set; }
        public string QvcItemNumberText { get; set; }

        
    }

}
