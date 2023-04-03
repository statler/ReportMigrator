using cpModel.Interfaces;
using cpModel.Helpers;

namespace cpModel.Dtos
{
    public partial class CnIncidentDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnIncidentId { get; set; }
        public int? IncidentId { get; set; }
        public int? IncidentNo { get; set; }
        public int? CnId { get; set; }
        public bool? InclNotice { get; set; }


        public bool? InclAtt { get; set; }
        private string incidentDesc;
        public string IncidentDesc
        {
            get => incidentDesc;
            set => incidentDesc = value.GetPlainTextFromHTML();
        }
        public string FullIncidentDesc => $"{IncidentNo}: {IncidentDesc}";
        public string ConRef { get; set; }
    }

}
// </auto-generated>


