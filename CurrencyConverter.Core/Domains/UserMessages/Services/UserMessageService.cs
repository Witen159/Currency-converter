using CurrencyConverter.Core.Domains.UserMessages.Repositories;
using CurrencyConverter.Core.Domains.Users.Repositories;
using CurrencyConverter.Core.Domains.Users.Services;

namespace CurrencyConverter.Core.Domains.UserMessages.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMessageRepository _userMessageRepository;
        private readonly IUserRepository _userRepository;

        public UserMessageService(IUnitOfWork unitOfWork, IUserMessageRepository userMessageRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userMessageRepository = userMessageRepository;
            _userRepository = userRepository;
        }

        public void AddMessage(string userID, string text)
        {
            var user = _userRepository.Get(userID);

            if (user == null)
            {
                return;
            }
            
            _userMessageRepository.Save(new UserMessage()
            {
                Text = text,
                UserId = userID
            });

            user.CountMessage++;
            _userRepository.Update(user);

            _unitOfWork.SaveChanges();
        }
    }
}