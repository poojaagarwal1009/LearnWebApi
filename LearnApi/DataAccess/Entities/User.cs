namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

    }
}
