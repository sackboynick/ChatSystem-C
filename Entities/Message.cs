using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Message
    {
        [Required]
        [JsonPropertyName("senderusername")]
        private readonly string _senderUsername;
        [Required]
        [JsonPropertyName("localdatetime")]
        [DataType(DataType.DateTime)]
        private readonly DateTime _localDateTime;
        [Required]
        [JsonPropertyName("text")]
        private readonly string _text;

        public Message(String senderUsername,String text){
            _senderUsername=senderUsername;
            _localDateTime=DateTime.Now;
            _text=text;
        }

        public String GetText() {
            return _text;
        }

        public String GetSenderUsername() {
            return _senderUsername;
        }

        public DateTime GetLocalDateTime() {
            return _localDateTime;
        }
    }
}