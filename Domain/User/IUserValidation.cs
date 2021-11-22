namespace Domain.User
{
    public interface IUserValidation
    {
        public Entities.User ValidateUser(string userName, string password);
    }
}