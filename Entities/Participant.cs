using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Participant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("user")]
        public string Username { get; set; }
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }
        
        [ForeignKey("GroupChatId")]
        public int GroupChatId { get; set; }

        public Participant()
        {
            Username = null;
            Admin = false;
        }

        public Participant(string username, bool admin)
        {
            Username = username;
            Admin = admin;
        }
        public Participant(int groupChatId,string username, bool admin)
        {
            Username = username;
            Admin = admin;
            GroupChatId = groupChatId;
        }
    }
}