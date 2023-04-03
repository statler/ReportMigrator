namespace cpModel.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public bool? InActive { get; set; }

        public string FullName { get; set; }

        public int? SubscriberId { get; set; }
        public string FirstLetter { get; set; }
        public string FirstLetterLastName { get; set; }
        public bool? IsSubscriptionAdmin { get; set; }
    }

    public class UserExtDto : UserDto
    {
        public Enums.SubscriptionRoleTypeEnum SubscriptionRoleType { get; set; }
        public bool IsExtAdmin { get; set; }
        public int ProjectsCount { get; set; }
    }

}
