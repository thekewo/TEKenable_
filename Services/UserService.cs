using TEKenable_Newsletter.Controllers;
using TEKenable_Newsletter.Data;
using TEKenable_Newsletter.Data.Interfaces;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _userRepository;

    public UserService(
        ILogger<UserService> logger,
        IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public bool SubmitNewsLetter(string email, string contactSource, string contactReason)
    {
        var contactSourceList = new List<string>() { "Advert", "Word of Mouth", "Other" };
        var contact = _userRepository.GetContactByEmail(email);

        if(contact == null && contactSourceList.Contains(contactSource)) _userRepository.AddContact(
            new User() { 
            Email = email, 
            ContactSource = contactSource, 
            ContactReason = contactReason 
            });
        else
        {
            return false;
        }

        return true;
    }

    public bool IsEmailInDatabase(string email)
    {
        var contact = _userRepository.GetContactByEmail(email);

        return contact != null;
    }
}