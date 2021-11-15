using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Friendship
    {
        [Required]
        [JsonPropertyName("username")]
        private readonly string _username;
        [Required]
        [JsonPropertyName("username")]
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