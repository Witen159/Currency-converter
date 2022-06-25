using CurrencyConverter.Core.Domains.Users;

namespace CurrencyConverter.Core.Domains.UserMessages
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
    }
}