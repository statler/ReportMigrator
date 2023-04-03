
using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Dtos.Template
{
    public class ContractNoticeFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Contract_Notice;

        public override List<TemplateField> GetTemplateFields()
        {
            return GetCnTemplateFieldList();
        }

        public static Lazy<List<TemplateField>> TemplateFieldList = new Lazy<List<TemplateField>>(() => GetCnTemplateFieldList());
        public static Lazy<List<string>> BasePropertyList = new Lazy<List<string>>(() => TemplateFieldList.Value.Where(x =>
            x.lstSubFields.Count == 0).Select(x => x.fieldName).ToList());
        public static Lazy<List<TemplateField>> CollectionList = new Lazy<List<TemplateField>>(() => TemplateFieldList.Value.Where(x => x.lstSubFields.Count > 0).ToList());

        public static Lazy<List<string>> CollectionNameList = new Lazy<List<string>>(() => CollectionList.Value.Select(x => x.fieldName).ToList());
        public static Lazy<List<string>> CollectionPropertyList = new Lazy<List<string>>(() => CollectionList.Value.SelectMany(x => x.lstSubFields.Select(y => y.fieldName)).ToList());
        public static Lazy<List<string>> AllPropertyList = new Lazy<List<string>>(() => BasePropertyList.Value.Union(CollectionPropertyList.Value).ToList());


        static public Dictionary<string, string> TranslatorFromV10()
        {
            var dctTranslate = new Dictionary<string, string>();
            dctTranslate["CN_Ref_As_Link"] = "Notice_Ref_With_Link";
            dctTranslate["CN_SiteLink_AsURL"] = "Notice_Link_AsURL";
            dctTranslate["Approval_ID_and_Desc"] = "Approval_No_and_Subject";
            dctTranslate["Approval_ID"] = "Approval_No";
            dctTranslate["CN_To"] = "CN_To_CSV";
            dctTranslate["CN_To_Company"] = "CN_To_Company_CSV";
            dctTranslate["CN_To_Address"] = "CN_To_Address_CSV";
            dctTranslate["NoticeSubjectAsPlain"] = "ConSubjectPlainText";
            return dctTranslate;
        }

        private static List<TemplateField> GetCnTemplateFieldList()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Project_No", "ProjectNumber"));
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Project_No_And_Name", "ProjectNumberAndName"));
            lstFields.Add(new TemplateField("CN_Ref", "ConRef"));
            lstFields.Add(new TemplateField("CN_Date", "ConDateAsString"));
            lstFields.Add(new TemplateField("CN_Subject", "ConSubjectPlainText"));
            lstFields.Add(new TemplateField("CN_Date_Required", "DateResponseRequiredAsString"));
            lstFields.Add(new TemplateField("CN_To_CSV", "CnToCSVString"));
            lstFields.Add(new TemplateField("CN_To_Company_CSV", "CnToCompany"));
            lstFields.Add(new TemplateField("CN_To_Address_CSV", "CnToAdressBlock"));

            lstFields.Add(new TemplateField("CN_From", "CNFrom"));
            lstFields.Add(new TemplateField("CN_From_Company", "CNFromCompany"));
            lstFields.Add(new TemplateField("CN_From_Address", "CNFromAddress"));
            lstFields.Add(new TemplateField("CN_From_Email", "CNFromEmail"));
            lstFields.Add(new TemplateField("CN_From_Mobile", "CNFromMobile"));
            lstFields.Add(new TemplateField("CN_On_Behalf_Of", "CNOnBehalfOf"));
            lstFields.Add(new TemplateField("CN_On_Behalf_Of_Company", "CNOnBehalfOfCompany"));
            lstFields.Add(new TemplateField("CN_On_Behalf_Of_Address", "CNOnBehalfOfAddress"));
            lstFields.Add(new TemplateField("CN_On_Behalf_Of_Email", "CNOnBehalfOfEmail"));
            lstFields.Add(new TemplateField("CN_On_Behalf_Of_Mobile", "CNOnBehalfOfMobile"));

            lstFields.Add(new TemplateField("Notice_Ref_With_Link", "ApprovalLink"));
            lstFields.Add(new TemplateField("Notice_Link_AsURL", "ApprovalLinkSiteURL"));

            var _addressees = new TemplateField("Addressees", "Addressees");
            _addressees.AddSubField(new TemplateField("CnTo_DisplayName", "DisplayName"));
            _addressees.AddSubField(new TemplateField("CnTo_Company", "Company"));
            _addressees.AddSubField(new TemplateField("CnTo_AddressBlock", "AddressBlock"));
            _addressees.AddSubField(new TemplateField("CnTo_Email", "Email"));
            lstFields.Add(_addressees);

            var _relatedNotices = new TemplateField("Related_Notices", "RelatedNotices");
            _relatedNotices.AddSubField(new TemplateField("RN_Ref", "ConRef"));
            _relatedNotices.AddSubField(new TemplateField("RN_Subject", "NoticeSubjectAsPlain"));
            _relatedNotices.AddSubField(new TemplateField("RN_Date", "ConDateAsString"));
            _relatedNotices.AddSubField(new TemplateField("RN_Date_Required", "DateResponseRequiredAsString"));
            _relatedNotices.AddSubField(new TemplateField("RN_Notice_To", "CnToCSVString"));
            _relatedNotices.AddSubField(new TemplateField("RN_On_Behalf_Of", "CNOnBehalfOf"));
            lstFields.Add(_relatedNotices);

            var _approvals = new TemplateField("Approvals", "Approvals");
            _approvals.AddSubField(new TemplateField("Approval_No", "ApprovalNo"));
            _approvals.AddSubField(new TemplateField("Approval_Subject", "SubjectPlainText"));
            _approvals.AddSubField(new TemplateField("Approval_No_and_Subject", "ApprovalNoAndSubject"));
            _approvals.AddSubField(new TemplateField("Approval_Request_Date", "RequestDateAsString"));
            _approvals.AddSubField(new TemplateField("Approval_Required_Date", "ActionDateAsString"));
            _approvals.AddSubField(new TemplateField("Approval_Description", "BodyHtmlNoDoc"));
            lstFields.Add(_approvals);

            var _variations = new TemplateField("Variations", "Variations");
            _variations.AddSubField(new TemplateField("VRN_No", "VariationNo"));
            _variations.AddSubField(new TemplateField("VRN_Description", "Description"));
            _variations.AddSubField(new TemplateField("VRN_No_and_Desc", "VariationNoDesc"));
            _variations.AddSubField(new TemplateField("VRN_Detail", "Detail"));
            _variations.AddSubField(new TemplateField("VRN_Client_Ref", "ClientRef"));
            _variations.AddSubField(new TemplateField("VRN_Date_Identified", "DateIdentifiedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Date_Notified", "DateNotifiedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Date_Submitted", "DateSubmittedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Date_Approved", "DateApprovedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Qty_Submitted", "QtySubmittedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Qty_Approved", "QtyApprovedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Rate_Submitted", "RateSubmittedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Rate_Approved", "RateApprovedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Total_Submitted", "TotalSubmittedAsString"));
            _variations.AddSubField(new TemplateField("VRN_Total_Approved", "TotalApprovedAsString"));
            lstFields.Add(_variations);

            var _lots = new TemplateField("Lots", "Lots");
            _lots.AddSubField(new TemplateField("Lot_No", "LotNumber"));
            _lots.AddSubField(new TemplateField("Lot_Description", "Description"));
            _lots.AddSubField(new TemplateField("Lot_No_and_Desc", "LotInclDef"));
            lstFields.Add(_lots);

            var _photos = new TemplateField("Photos", "Photos");
            _photos.AddSubField(new TemplateField("Photo_ID", "PhotoId"));
            _photos.AddSubField(new TemplateField("Photo_Date", "PhotoDateAsString"));
            _photos.AddSubField(new TemplateField("Photo_Description", "Description"));
            _photos.AddSubField(new TemplateField("Photo_ID_and_Desc", "PhotoIdAndDescription"));
            lstFields.Add(_photos);

            var _itps = new TemplateField("ITPs", "Itps");
            _itps.AddSubField(new TemplateField("ITP_Doc_No", "ItpDocnumber"));
            _itps.AddSubField(new TemplateField("ITP_Description", "Description"));
            _itps.AddSubField(new TemplateField("ITP_Doc_No_and_Desc", "ItpNoDesc"));
            _itps.AddSubField(new TemplateField("ITP_Specification_Ref", "SpecRef"));
            _itps.AddSubField(new TemplateField("ITP_Revision_Date", "RevisionDateAsString"));
            _itps.AddSubField(new TemplateField("ITP_Approval_Date", "ApprovalDateAsString"));
            lstFields.Add(_itps);

            var _fsDocs = new TemplateField("Filestore", "FilestoreDocs");
            _fsDocs.AddSubField(new TemplateField("Filestore_No", "FileStoreDocNo"));
            _fsDocs.AddSubField(new TemplateField("FileStore_FileDate", "FileDateAsString"));
            _fsDocs.AddSubField(new TemplateField("FileStore_Description", "Description"));
            _fsDocs.AddSubField(new TemplateField("Filestore_No_And_Desc", "FsNoInclDesc"));
            lstFields.Add(_fsDocs);

            var _contDocs = new TemplateField("Controlled_Docs", "ControlledDocs");
            _contDocs.AddSubField(new TemplateField("Document_No", "DocumentNo"));
            _contDocs.AddSubField(new TemplateField("Document_Description", "Description"));
            _contDocs.AddSubField(new TemplateField("Document_No_and_Desc", "DocNoAndDesc"));
            _contDocs.AddSubField(new TemplateField("Document_Latest_Rev._Ref", "LastRevRefOrInitial"));
            _contDocs.AddSubField(new TemplateField("Document_Latest_Rev._Date", "LastRevDateOrInitialAsString"));
            _contDocs.AddSubField(new TemplateField("Document_DocNo_Latest_Rev._Ref", "DocNoLastRevRefOrInitial"));
            _contDocs.AddSubField(new TemplateField("Document_DocNo_Latest_Rev._Date", "DocNoLastRevDateOrInitial"));
            lstFields.Add(_contDocs);

            var _instructions = new TemplateField("Instructions", "Instructions");
            _instructions.AddSubField(new TemplateField("Instruction_Id", "InstructionId"));
            _instructions.AddSubField(new TemplateField("Instruction_Date", "InstructionDateAsString"));
            _instructions.AddSubField(new TemplateField("Instruction_Description", "DescriptionHtml"));
            _instructions.AddSubField(new TemplateField("Instruction_To", "InstructionToName"));
            _instructions.AddSubField(new TemplateField("Instruction_By", "InstructionByName"));
            lstFields.Add(_instructions);

            var _incident = new TemplateField("Incidents", "Incidents");
            _incident.AddSubField(new TemplateField("Incident_Id", "IncidentId"));
            _incident.AddSubField(new TemplateField("Incident_Date", "IncidentDateAsString"));
            _incident.AddSubField(new TemplateField("Incident_Description", "DescriptionHtml"));
            _incident.AddSubField(new TemplateField("Incident_Type", "IncidentTypeName"));
            _incident.AddSubField(new TemplateField("Incident_Identified_by", "RaisedByName"));
            lstFields.Add(_incident);
            return lstFields;
        }

    }
}
