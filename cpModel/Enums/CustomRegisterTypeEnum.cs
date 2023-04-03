using cpModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace cpModel.Enums
{
    public enum CustomRegisterTypeEnum
    {
        None = 0,
        Lot = 10,
        TestRequest = 20,
        Ncr = 30,
        //Survey = 40,
        //ATP = 50,
        Checklist = 100,
        //ChecklistItem = 110,
        //Approval = 120,
        //ITP = 130,
        Quantity = 140,
        Variation = 150,
        ContractNotice = 200,
        //ContractNoticeResponse = 210,
        //Transmittal = 300,
        Daycost = 500,
        //SiteDiary = 510,
        //PurchaseOrder = 520,
        Invoice = 530,
        CostCode = 800
    }
}