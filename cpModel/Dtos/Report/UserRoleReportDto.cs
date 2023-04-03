using cpModel.Enums;
using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class UserRoleReportDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string FullNameWithEmail => $"{FullName} ({Email})";
        public string FullNameWithCompanyAndEmail => $"{FullName} ({Email}) - {(string.IsNullOrWhiteSpace(Company) ? "" : Company + " ")}";
        public string RoleName { get; set; }
        public string RoleNameWithType => $"{RoleName} ({SubscriptionRoleType.ToString()})";
        public decimal? PoApprovalLimit { get; set; }
        public decimal? InvoiceApprovalLimit { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectNumberAndName => ProjectNumber == null ? ProjectName : ProjectNumber + ": " + ProjectName;
        public SubscriptionRoleTypeEnum? SubscriptionRoleType { get; set; }
    }
}
