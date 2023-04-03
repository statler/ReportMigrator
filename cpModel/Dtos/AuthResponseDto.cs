using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string ErrorMsg { get; set; }
        public bool RequireMFA_email { get; set; }
        public bool RequireMFA_SMS { get; set; }
        public bool HasError
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ErrorMsg);
            }
        }

        /// <summary>
        /// response from API - email to use for SMS MFA
        /// </summary>
        public string signInEmail { get; set; }

        public static string ErrorCode_MFA_email = "requireMFA_email";
        public static string ErrorCode_MFA_SMS = "requireMFA_SMS";
    }
}
