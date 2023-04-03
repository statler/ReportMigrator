using System;

namespace cpModel.Dtos.Template
{
    public class UserAddresseeTemplateDto : UserDto
    {
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }

        public string NL => Environment.NewLine;

        public string DisplayName
        {
            get
            {
                var firstLast = FirstName + ' ' + LastName;
                if (string.IsNullOrWhiteSpace(firstLast)) return Email;
                return firstLast;
            }
        }

        public string AddressBlock
        {
            get
            {
                return $"{Address ?? ""}{NL}{Suburb ?? ""}{NL}{State ?? ""} {Postcode ?? ""}{NL}Ph:{Phone ?? ""}{NL}";
            }
        }
    }
}
