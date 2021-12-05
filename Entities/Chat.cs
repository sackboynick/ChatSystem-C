using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Chat {
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("messages")]
        public ICollection<Message> Messages { get; set; }
        [Required]
        [JsonPropertyName("sender")]
        public string Sender { get; set; }
        [Required]
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }
        

        public Chat(){
            Messages=new List<Message>();
        }

        public Chat(string sender, string receiver)
        {
            Sender = sender;
            Receiver = receiver;
        }
        
    }
}