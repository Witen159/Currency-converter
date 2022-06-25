namespace CurrencyConverter.Core.Domains.UserMessages.Repositories
{
    public interface IUserMessageRepository
    {
        void Save(UserMessage userMessage);
    }
}