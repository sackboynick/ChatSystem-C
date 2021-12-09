using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Friendship
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("friendUsername")]
        public string Username{ get; set; } 
        [Required]
        [JsonPropertyName("closeFriend")]
        public bool CloseFriend { get; set; } 
        
        [ForeignKey("User")]
        public int UserId { get; set; }

        public Friendship()
        {

            Username = null;
            CloseFriend = false;
        }

        public Friendship(string username,bool closeFriend) {
            Username=username;
            CloseFriend=closeFriend;
        }
        
        public Friendship(int userId,string username,bool closeFriend) {
            Username=username;
            CloseFriend=closeFriend;
            UserId = userId;
        }

    }
}