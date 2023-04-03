using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Other
{

    public enum LotComponentType
    {
        Conformance_Report,
        Quantity_Agreement,
        Photo,
        NCR,
        ATP,
        Checklist,
        Direct_Approvals,
        Test_Request,
        Survey,
        Filestore_Doc_Lot,
        Filestore_Doc_ChecklistApproval,
        Filestore_Doc_DirectApproval,
        Filestore_Doc_NCR,
        Filestore_Doc_NCRApproval,
        Filestore_Doc_TestRequest,
        Filestore_Doc_Survey,
        Filestore_Doc_LotMap,
        Instruction,
        Filestore_Doc_Instruction,
        Contract_Notice,
        Filestore_Doc_ContractNotice
    }


    public class FsBasic
    {
        public int FileStoreDocId { get; set; }
        public int KeyId { get; set; }
        public string Description { get; set; }
        public FsBasic()
        {
        }
    }
}
