using cpModel.Enums;
using cpShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class LicenseInfo
    {

        public AuthenticationProviderEnum AuthProvider { get; set; }
        public string UserName { get; set; }
        public string APIUrl { get; set; }
        public string ValidationTokenUid { get; set; }
        public DateTime? LastFullValidation { get; set; }
        public DateTime? LastTokenValidation { get; set; }
        public ConnectionProperties Connection { get; set; }


        public LicenseInfo(AuthenticationProviderEnum authProvider, string userName, string aPIUrl, string validationTokenUid, DateTime lastFullValidation, DateTime lastTokenValidation)
        {
            AuthProvider = authProvider;
            UserName = userName;
            APIUrl = aPIUrl;
            ValidationTokenUid = validationTokenUid;
            LastFullValidation = lastFullValidation;
            LastTokenValidation = lastTokenValidation;
        }

        public LicenseInfo()
        {
        }
    }
}
