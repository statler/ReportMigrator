using cpModel.Enums;
using cpModel.Helpers;
using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public partial class LotItpTemplateDto
    {
        public virtual ICollection<LotShortListDto> Lots { get; set; }
        public string ChecklistDateString => ChecklistDate == null ? "" : ChecklistDate.Value.ToShortDateString();

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Checklist_Notification, LotItpId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;
        public string ChecklistLink => $@"<a href='{URL}'>{LotNumber}({ItpName})</a>";
        public string ChecklistLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";


        public int LotItpId { get; set; }
        public string Description { get; set; }
        public int? LotId { get; set; }
        public int? ItpId { get; set; }
        public int? RaisedById { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? ChecklistDate { get; set; }
        public string SourceItpNo { get; set; }
        public string SourceQvcNo { get; set; }
        public int? Priority { get; set; }
        public int PriorityEff { get => Priority ?? (int)PriorityEnum.Normal; set => Priority = value; }

        public string LotNumber { get; set; }
        public string ItpDescription { get => ItpName; set => ItpName = value; }
        public string RaisedByName { get; set; }
        public string ApprovedByName { get; set; }

        public string DescInclLot => string.IsNullOrWhiteSpace(LotNumber) ? Description : $"{LotNumber}: {Description}";
        public DateTime? DateRejected { get; set; }
        public DateTime? DateConformed { get; set; }
        public DateTime? DateGuaranteed { get; set; }
        public DateTime? EffectiveCloseDate => DateApproved ?? DateConformed ?? DateGuaranteed;

        public string Status { get; set; }

        public string ItpName { get; set; }

        public bool IsClosedOut => DateApproved != null;
    }

}
