using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public partial class LotItpStatusReportDto : LotItpDto
    {
        public List<LotItpDetailStatusReportDto> lstDetailStatus { get; set; }

        //For IsCE compatibility
        public override string Status
        {
            get
            {
                if (LotId == null) return "No Lot Ref";
                if (DateRejected != null) return Models.Lot.RejectedString;
                if (DateConformed != null) return "Conformed";
                if (DateGuaranteed != null) return "Guaranteed";
                if (DateApproved != null) return "Closed";
                else return "Open";
            }
        }

        public int StatusOrder
        {
            get
            {
                if (Status == "No Lot Ref") return 6;
                if (Status == Models.Lot.RejectedString) return 5;
                if (Status == "Conformed") return 4;
                if (Status == "Guaranteed") return 3;
                if (Status == "Closed") return 2;
                else return 1;
            }
        }
    }
}
