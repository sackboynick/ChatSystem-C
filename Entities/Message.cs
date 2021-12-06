using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("senderusername")]
        public string SenderUsername { get; set; }
        [JsonPropertyName("receiverusername")]
        public string ReceiverUsername { get; set; }
        [Required]
        [JsonPropertyName("localdatetime")]
        [DataType(DataType.DateTime)]
        public DateTime LocalDateTime { get; set; }
        [Required]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        public Message()
        {
            SenderUsername = null;
            LocalDateTime = new DateTime();
            Text = null;
        }

        public Message(string senderUsername,string receiverUsername,String text){
            SenderUsername=senderUsername;
            ReceiverUsername = receiverUsername;
            LocalDateTime=DateTime.Now;
            Text=text;
        }
        public Message(string senderUsername,String text){
            SenderUsername=senderUsername;
            ReceiverUsername = null;
            LocalDateTime=DateTime.Now;
            Text=text;
        }


    }
}