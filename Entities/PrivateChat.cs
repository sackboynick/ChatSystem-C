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
            this._sender=sender;
            this._receiver=receiver;
        }

        public string GetReceiver() {
            return _receiver;
        }

        public string GetSender() {
            return _sender;
        }

        public List<Message> GetMessages() {
            return base.GetMessages();
        }
    }
}