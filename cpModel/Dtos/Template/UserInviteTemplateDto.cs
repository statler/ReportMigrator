using cpModel.Enums;
using cpModel.Helpers;

namespace cpModel.Dtos.Template
{
    public class UserInviteTemplateDto : UserInviteDto
    {
        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }
        public string ExpiryDateString => ExpiryDate == null ? "" : ExpiryDate.Value.ToString("d");
        public bool RequiresPaidSubscription { get; set; }

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.User_Invite, UniqueId.Value);

        public string UserInviteLinkSiteURL => $@"<a href='{URL}'>{URL}</a>" ;
        public string RegistrationInviteLinkSiteURL { get; set; }

    }
}
