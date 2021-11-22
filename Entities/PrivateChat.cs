using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class PrivateChat:Chat
    {

        [Required]
        [JsonPropertyName("sender")]
        public string Sender { get; set; }
        [Required]
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }

        public PrivateChat()
        {
            Sender = null;
            Receiver = null;
        }
        public PrivateChat(string sender,string receiver){
            Sender=sender;
            Receiver=receiver;
        }



    }
}