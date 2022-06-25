namespace CurrencyConverter.Core.Domains.UserMessages.Services
{
    public interface IUserMessageService
    {
        void AddMessage(string userID, string text);
    }
}