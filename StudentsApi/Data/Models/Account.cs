namespace StudentsApi.Data.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Password Password { get; set; }
    }
}
