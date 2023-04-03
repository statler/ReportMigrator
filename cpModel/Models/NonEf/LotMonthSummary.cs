using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Models.NonEf
{
    public class LotMonthSummary
    {
        public DateTime Period { get; set; }
        public int LotOpenAtEOM { get; set; }
        public int LotConfAtEOM { get; set; }
        public int LotGuarAtEOM { get; set; }
        public int LotsOpened { get; set; }
        public int LotsConformed { get; set; }
        public int LotsGuaranteed { get; set; }
        public int TotalLots { get; set; }
        public int NCROpenAtEOM { get; set; }
        public int NCRAppAtEOM { get; set; }
        public int NCRClsdAtEOM { get; set; }
        public int NCROpened { get; set; }
        public int NCRsApproved { get; set; }
        public int NCRsClosedOut { get; set; }
        public int TotalNCRs { get; set; }
        public int VRNIdentAtEOM { get; set; }
        public int VRNNfyAtEOM { get; set; }
        public int VRNAppAtEOM { get; set; }
        public int VRNIdentified { get; set; }
        public int VRNNotified { get; set; }
        public int VRNApproved { get; set; }
        public int TotalVRN { get; set; }
        public int TrOpened { get; set; }
        public int TrCompleted { get; set; }
        public int TrOpenAtEOM { get; set; }
        public int TrCompleteAtEOM { get; set; }
        public int TotalTR { get; set; }


        public LotMonthSummary(DateTime period)
        {
            Period = period;
        }

        /// <summary>
        /// Initializes a new instance of the LotMonthSummary class.
        /// </summary>
        public LotMonthSummary(DateTime period, int totalLots, int openLots, int confLots, int guarLots, int lotsOpened, int lotsConformed, int lotsGuaranteed)
        {
            Period = period;
            TotalLots = totalLots;
            LotOpenAtEOM = openLots;
            LotConfAtEOM = confLots;
            LotGuarAtEOM = guarLots;
            LotsOpened = lotsOpened;
            LotsConformed = lotsConformed;
            LotsGuaranteed = lotsGuaranteed;
        }

    }
}
