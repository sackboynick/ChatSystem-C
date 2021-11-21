using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class PrivateChat:Chat
    {

        [Required]
        [JsonPropertyName("sender")]
        private string _sender;
        [Required]
        [JsonPropertyName("receiver")]
        private string _receiver;

        public PrivateChat(string sender,string receiver){
            _sender=sender;
            _receiver=receiver;
        }

        public string GetReceiver() {
            return _receiver;
        }

        public string GetSender() {
            return _sender;
        }

        public new ICollection<Message> GetMessages() {
            return base.GetMessages();
        }
    }
}