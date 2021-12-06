using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class PrivateChat:Chat
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("participant1")]
        public string Participant1 { get; set; }
        [Required]
        [JsonPropertyName("participant2")]
        public string Participant2 { get; set; }


        public PrivateChat()
        {
            Participant1 = null;
            Participant2 = null;
        }
        public PrivateChat(string participant1,string participant2){
            Participant1=participant1;
            Participant2=participant2;
        }



    }
}