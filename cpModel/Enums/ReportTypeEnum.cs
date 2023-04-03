using System;
using System.Linq;
using System.Collections.Generic;

namespace cpModel.Enums
{
    //ALWAYS append to end!
    public enum ReportTypeEnum
    {
        None,
        Approval = 1,
        ATP = 2,
        Lot = 3,
        Production = 4,
        NCR = 5,
        Schedule = 6,
        Claim = 7,
        TestReq = 8,
        LotITP = 9,
        ITP = 10,
        Variation = 11,
        Photo = 12,
        PurchaseOrder = 13,
        Risk = 14,
        Invoice = 15,
        Receipt = 16,
        Daycost = 17,
        Forecast = 18,
        ForecastWinLoss = 19,
        ForecastCostEstimate = 20,
        VariationEstimate = 21,
        Dashboard = 22,
        Filestore = 23,
        ContractNotice = 24,
        EmailLog = 25,
        LotQty = 26,
        Incident = 27,
        SiteDiary = 28,
        DocsAndTransmittals = 29,
        Permission = 30,
        Instruction = 31,
        SurveyRequest = 32,
        Notification = 33,
        Punchlist = 34,
        User = 35
    }
}
