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

        public Message(String senderUsername,String text){
            SenderUsername=senderUsername;
            LocalDateTime=DateTime.Now;
            Text=text;
        }


    }
}