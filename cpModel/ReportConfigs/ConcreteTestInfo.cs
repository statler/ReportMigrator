using cpModel.Dtos;
using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpModel.ReportConfigs
{
    public class ConcreteTestInfo
    {
        public int TestMethodId { get; set; }
        public float Fc { get; set; }
        public float Ft { get; set; }
        public ConcreteTestTypes Concrete_TestTypes { get; set; }
        public List<int> CylinderResultFieldIds;
        public ConcreteTestInfo()
        {

        }
    }
}
