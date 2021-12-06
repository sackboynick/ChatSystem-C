using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Participant
    {
        
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("user")]
        public string Username { get; set; }
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

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
    }
}