
using cpModel.Helpers;
using cpModel.Interfaces;
using cpShared.Extensions;

namespace cpModel.Dtos
{
    public partial class ContactDto : ContactListDto, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int? ProjectId { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public string FirstLast { get; set; }
        public string Notes { get; set; }

        public string Initials => FirstName.Left(1) + LastName.Left(1);

    }

}
