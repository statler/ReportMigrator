
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using bm = cpModel.Models;

namespace cpModel.Models.V10ImportModels
{

    public partial class ITPTesting
    {
        public int ITPTestID { get; set; }
        public int ITPDetailID { get; set; }
        public int TestMethodID { get; set; }
        public decimal FreqNorm { get; set; }
        public decimal FreqRed { get; set; }
        public decimal FreqLotNorm { get; set; }
        public decimal FreqLotRed { get; set; }
        public string Unit { get; set; }
        public int? QuantityBasis { get; set; }
        public string Compliance { get; set; }
        public int? ORset { get; set; }
        public string Comment { get; set; }
        public bool IsOptional { get; set; }
        public bool IsDefault { get; set; }
        
    }

}
