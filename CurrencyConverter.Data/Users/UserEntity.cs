namespace CurrencyConverter.Data.Users
{
    public class UserEntity
    {
        // only in db model
        public int UserId { get; set; }
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}