namespace TEKenable_Newsletter.Data.Interfaces
{
    public interface IUserRepository
    {
        void AddContact(User user);
        User GetContactByEmail(string email);
    }
}
