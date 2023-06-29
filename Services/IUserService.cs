public interface IUserService
{
    public bool SubmitNewsLetter(string email, string contactSource, string contactReason);
    public bool IsEmailInDatabase(string email);
}