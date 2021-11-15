namespace Entities
{
    public class Friendship
    {
        private readonly string _username;
        private readonly bool _closeFriend;

        public Friendship(string username,bool closeFriend) {
            _username=username;
            _closeFriend=closeFriend;
        }

        public string GetUsername() {
            return _username;
        }

        public bool IsCloseFriend() {
            return _closeFriend;
        }
    }
}