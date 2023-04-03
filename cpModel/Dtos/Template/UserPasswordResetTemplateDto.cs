using cpModel.Enums;
using cpModel.Helpers;
using System;

namespace cpModel.Dtos.Template
{
    public class UserPasswordResetTemplateDto : UserDto
    {
        public DateTime? DatePasswordResetRequested { get; set; }
        public DateTime? DatePasswordRequestExpires => DatePasswordResetRequested?.AddDays(1);
        public string DatePasswordRequestExpiresString => DatePasswordRequestExpires == null ? "" : DatePasswordRequestExpires.Value.ToString("d");
        public Guid? PasswordRequestToken { get; set; }
        public string MobileSiteURL { get; set; }
        public string UserPasswordResetLinkSiteURL => APIConstants.GetURLString(TemplateTypeEnum.User_Password_Reset, UserId.ToString(), PasswordRequestToken.HasValue ? PasswordRequestToken.ToString() : "");
    }
}
