using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class PunchlistUserDto
    {
        public int PunchlistUserId { get; set; }
        public int? UserId { get; set; }
        public int? PunchlistId { get; set; }
        public int? ScopeId { get; set; }
        public string UserFullName { get; set; }
        public string ScopeName => ScopeId == null ? "" : Enum.GetName(typeof(PunchlistScopeEnum), ScopeId);
    }
}
