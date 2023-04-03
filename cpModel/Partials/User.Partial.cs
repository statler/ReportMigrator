namespace cpModel.Models
{
    public partial class User
    {
        public string FirstLast => $"{FirstName} {LastName}";
        public override string ToString()
        {
            return UserId.ToString();
        }

        public bool CanSSOLogin => !string.IsNullOrWhiteSpace(FirebaseId);
        public bool CanCPLogin => !(IsOnline ?? false) && !string.IsNullOrWhiteSpace(Password);
    }
}
// </auto-generated>
