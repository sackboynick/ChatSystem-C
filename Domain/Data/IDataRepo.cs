using Entities;

namespace Domain.Data
{
    public interface IDataRepo
    {
        public void SendMessage(Message message);
    }
}