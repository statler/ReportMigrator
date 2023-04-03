using cpModel.Enums;
using cpModel.Helpers;
using System;

namespace cpModel.Dtos.Template
{
    public class LotTemplateDto : LotBasicTemplateDto
    {
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Lot_Notification, LotId);
        public string LotLink => $@"<a href='{URL}'>{LotNumber}</a>";
        public string LotLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public string DateOpenString => DateOpen == null ? "" : DateOpen.Value.ToShortDateString();
        public string DateGuarString => DateGuar == null ? "" : DateGuar.Value.ToShortDateString();
        public string DateConfString => DateConf == null ? "" : DateConf.Value.ToShortDateString();
        public string LotStatus { get; set; }
        public int DaysOpen => DateOpen != null && DateGuar == null && DateConf == null ? (DateTime.Now - DateOpen.Value).Days:0;
        public string RaisedByName { get; set; }
    }
}
