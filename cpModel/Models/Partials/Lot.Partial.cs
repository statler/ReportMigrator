using cpModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Models
{
    public partial class Lot
    {
        public static string BaseRejectedString = "Rejected";
        public static string RejectedString = "Rejected";
        public static string RejectedStringVerb = "Reject";


        public bool HasChainageData => ((ChStart ?? 0) != 0) || ((ChEnd ?? 0) != 0) || (ControlLineId != null);
    }
}
