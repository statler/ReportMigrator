
using cpModel.Enums;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class RegisterAccessReportDto
    {
        public bool IsAbsolute => RegisterKey >= 1000;
        public int RegisterKey { get; set; }
        public string RegisterKeyName => ((PermissionDomainEnum)RegisterKey).ToString();
        public int AccessKey { get; set; }
        public string AccessKeyName => ((PermissionAccessEnum)AccessKey).ToString();
        public List<StringWrapper> lstRoleNames { get; set; }
        public List<int> lstRoleIds { get; set; }
        public List<StringWrapper> lstUserNames { get; set; }
    }

    public class StringWrapper
    {
        public string NameAsString { get; set; }
        public StringWrapper(string nameAsString)
        {
            NameAsString = nameAsString;
        }
    }
}
