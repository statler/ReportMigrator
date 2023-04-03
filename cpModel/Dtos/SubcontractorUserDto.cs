using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class SubcontractorUserDto
    {
        public int SubcontractorUserId { get; set; }
        public int? SubcontractorId { get; set; }
        public int? UserId { get; set; }
        public string SubcontractorName { get; set; }
        public string UserFullName { get; set; }
    }

}
