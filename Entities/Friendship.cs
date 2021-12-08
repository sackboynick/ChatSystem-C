using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Friendship
    {
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("friendUsername")]
        public string Username{ get; set; } 
        [Required]
        [JsonPropertyName("closeFriend")]
        public bool CloseFriend { get; set; } 

        public Friendship()
        {

            Username = null;
            CloseFriend = false;
        }

        public Friendship(string username,bool closeFriend) {
            Username=username;
            CloseFriend=closeFriend;
        }

    }
}