

using cpModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace cpModel.Enums
{
    public class CpEnum
    {
        public enum v10_ProjectPermission
        {
            ProjectAdmin = 1,
            ProjectUser = 2,
            ATPApprove = 3,
            ITPApprove = 4,
            ITPCheck = 5,
            ITPVerify = 6,
            NCRApprove = 7,
            QtyApprove = 8,
            ConformLot = 9,
            SupplierAdd = 10,
            ContractNoticeAdmin = 11,
            //POSupplierAgree = 12,
            XProjectHSEQAdmin = 13,
            XProjectFinanceAdmin = 14,
            TestReqAttach = 15,
            ClaimCertify = 16,
            ContractNoticeUser = 17,
            ClaimAndForecastAdmin = 18,
            GuaranteeLot = 20,
            Subcontractor = 50,
            SysAdmin = 100
        }

        /// <summary>
        ///  Return human-readable string from Enum e.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="translateChars"></param>
        /// <returns>Either:
        ///    [Description("Some desc!")]
        ///    Enum.ToString()
        ///    if translateChars: Enum.ToString with _ replaced by spaces, and caps and ancronyms separated with spaces
        ///      (aWordAndTLAAcronym -> a Word And TLA Acronym)
        /// </returns>
        public static string GetDescription(Enum e)
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return enumAttributes.FirstOrDefault()?.Description ?? e.ToString().SpaceCapitals().Replace('_', ' ');
        }

        public class EnumDto<Tenum>
        {
            public Tenum EnumId { get; set; }
            public int EnumInt { get; set; }
            public string Description { get; set; }
            public EnumDto()
            {
            }
        }

        public static IEnumerable<EnumDto<Tenum>> GetEnumDto<Tenum>()
            where Tenum : Enum
        {
            return Enum.GetValues(typeof(Tenum)).Cast<Tenum>()
                .Select(e => new EnumDto<Tenum> { EnumId = e, EnumInt = e.EnumToInt(), Description = GetDescription(e) });
        }
    }
}
