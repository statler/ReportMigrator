using System;
using System.Collections.Generic;
using System.Linq;
using cpModel.Enums;
using cpModel.Helpers;

namespace cpModel.Dtos.Template
{
    public class ContractNoticeRenderTemplateDto : ContractNoticeDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumberAndName => $"{ProjectNumber} - {ProjectName}";
        public string ConDateAsString => ConDate?.ToShortDateString() ?? "";
        public string DateResponseRequiredAsString => DateResponseRequired?.ToShortDateString() ?? "";
        public string CnToCSVString => Addressees == null ? "" : String.Join(", ", Addressees.Where(x => !string.IsNullOrEmpty(x.DisplayName)).Select(x => x.DisplayName));
        public string CnToCompany => Addressees == null ? "" : String.Join(", ", Addressees.Where(x => !string.IsNullOrEmpty(x.Company)).Select(x => x.Company).Distinct());
        public string CnToAdressBlock => Addressees == null ? "" : String.Join(", ", Addressees.Where(x => !string.IsNullOrEmpty(x.AddressBlock)).Select(x => x.AddressBlock).Distinct());

        public UserAddresseeTemplateDto RequestBy { get; set; }
        public UserAddresseeTemplateDto RequestOnBehalf { get; set; }
        public string CNFrom => RequestBy?.DisplayName ?? "";
        public string CNFromCompany => RequestBy?.Company ?? "";
        public string CNFromAddress => RequestBy?.AddressBlock ?? "";
        public string CNFromEmail => RequestBy?.Email ?? "";
        public string CNFromMobile => RequestBy?.Mobile ?? "";
        public string CNOnBehalfOf => RequestOnBehalf?.DisplayName ?? "";
        public string CNOnBehalfOfCompany => RequestOnBehalf?.Company ?? "";
        public string CNOnBehalfOfAddress => RequestOnBehalf?.AddressBlock ?? "";
        public string CNOnBehalfOfEmail => RequestOnBehalf?.Email ?? "";
        public string CNOnBehalfOfMobile => RequestOnBehalf?.Mobile ?? "";

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Contract_Notice, ConId);
        public string ApprovalLink => $@"<a href='{URL}'>{ConRef}</a>";
        public string ApprovalLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";


        ////Code populated collections
        public List<UserAddresseeTemplateDto> Addressees { get; set; }
        public List<ContractNoticeRenderTemplateDto> RelatedNotices { get; set; }
        public List<ApprovalSimpleTemplateDto> Approvals { get; set; }
        public List<VariationTemplateDto> Variations { get; set; }
        public List<LotBasicTemplateDto> Lots { get; set; }
        public List<PhotoTemplateDto> Photos { get; set; }
        public List<ItpTemplateDto> Itps { get; set; }
        public List<FileStoreDocTemplateDto> FilestoreDocs { get; set; }
        public List<CpDocumentTemplateDto> ControlledDocs { get; set; }
        public List<IncidentTemplateDto> Incidents { get; set; }
        public List<InstructionTemplateDto> Instructions { get; set; }


    }
}
