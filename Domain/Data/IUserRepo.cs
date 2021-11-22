namespace Domain.Data
{
    public interface IUserRepo
    {
        public Entities.User ValidateUser(string userName, string password);
    }
}