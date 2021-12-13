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
        [JsonPropertyName("closeFriend")]
        public bool CloseFriend { get; set; } 
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [ForeignKey("FriendUser")]
        public int FriendUserId { get; set; }

        public Friendship()
        {
            CloseFriend = false;
        }

        public Friendship(bool closeFriend) {
            CloseFriend=closeFriend;
        }
        
        public Friendship(int userId,int friendUserId,bool closeFriend) {
            CloseFriend=closeFriend;
            UserId = userId;
            FriendUserId = friendUserId;
        }

    }
}