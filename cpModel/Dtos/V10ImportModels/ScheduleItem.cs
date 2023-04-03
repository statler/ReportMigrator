
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using bm = cpModel.Models;

namespace cpModel.Models.V10ImportModels
{

    public partial class ScheduleItem
    {
        public int ScheduleID { get; set; }
        public int ProjectID { get; set; }
        public decimal OrderID { get; set; }
        public int ParentID { get; set; }
        public string ScheduleGroup { get; set; }
        public string ScheduleNumber { get; set; }
        public string Description { get; set; }
        public decimal? QtyForecast { get; set; }
        public decimal? QtyScheduled { get; set; }
        public string Unit { get; set; }
        public decimal? DJCRate { get; set; }
        public decimal? SellRate { get; set; }
        public bool IsTotalled { get; set; }
        public string Notes { get; set; }
        public bool IsVRN { get; set; }
        public bool disable { get; set; }
        public bool isOverhead { get; set; }
        public bool isVariableRate { get; set; }

    }

}
