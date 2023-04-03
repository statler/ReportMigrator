using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class UserReportDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Company { get; set; }
        public string FullName { get; set; }
        public string FullNameWithEmail => $"{FullName} ({Email})";
        public string FullNameWithCompanyAndEmail => $"{FullName} ({Email}) - {(string.IsNullOrWhiteSpace(Company) ? "" : Company + " ")}";
        public bool? InActive { get; set; }
        public List<UserRoleReportDto> lstRoles { get; set; } = new List<UserRoleReportDto>();
    }
}
