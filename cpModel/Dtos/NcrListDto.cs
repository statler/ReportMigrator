using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class NcrListDto
    {
        public int NcrId { get; set; }
        public int? NcrNo { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime? DateRaised { get; set; }
        public int? RaisedById { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? CloseOutDate { get; set; }
        public int? ApprovalId { get; set; }
        public DateTime? DatePublished { get; set; }

        public string Status { get; set; }
        public string RaisedByName { get; set; }
        public bool IsApprovalComplete { get; set; }
        public bool IsApprovedToProceed { get; set; }
        public bool IsLatestStepAlert { get; set; }

        public decimal? NcrCost { get; set; }
        public decimal? LqSell { get; set; }
        public decimal? LqRpVal { get; set; }
        //public List<string> lstLotNumbers { get; set; }
        //public string LotNumberString => String.Join(", ", lstLotNumbers);
        public bool HasApproval => ApprovalId != null;

        public string ApprovedByName { get; set; }

        public string ApprovalDetails { get; set; }

        public string CloseoutByName { get; set; }
        public bool IsClosedOut
        {
            get
            {
                return CloseOutDate != null;
            }
        }
        public string ApprovalRemarks { get; set; }
        public int? ThirdPartyAppReqd { get; set; }

        public string CorrectiveAction { get; set; }
        public string PreventativeAction { get; set; }
        public string RootCauseDetail { get; set; }
        public string RootCauseCategory { get; set; }

        public string Notes { get; set; }
        public int? Severity { get; set; }
        public int? ActionType { get; set; }

    }
}
