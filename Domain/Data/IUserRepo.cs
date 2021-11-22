namespace Domain.Data
{
    public interface IUserRepo
    {
        public User ValidateUser(string userName, string password);
    }
}