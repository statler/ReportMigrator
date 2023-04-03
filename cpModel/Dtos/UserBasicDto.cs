using cpModel.Helpers;
using cpShared.Extensions;

namespace cpModel.Dtos
{
    public partial class UserBasicDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string FirstLast { get; set; }
        public bool? InActive { get; set; }

        public string Initials => FirstName.Left(1) + LastName.Left(1);
        public string CustomInitials { get; set; }
    }

}
