namespace cpModel.Dtos
{
    public class ContactListDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public string FirstLetter { get; set; }
        public string FirstLetterLastName { get; set; }


        public string FullName { get; set; }
        public bool IsUser { get; set; }
    }

}
