using cpModel.Helpers;
using cpShared.Extensions;

namespace cpORM.Dtos
{
    public partial class ContactLookupDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public string Initials => FirstName.Left(1) + LastName.Left(1);

    }

}
