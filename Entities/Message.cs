using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("senderusername")]
        public string SenderUsername { get; set; }
        [JsonPropertyName("receiverusername")]
        public string ReceiverUsername { get; set; }
        [Required]
        [JsonPropertyName("localdatetime")]
        public String LocalDateTime { get; set; }
        [Required]
        [JsonPropertyName("text")]
        public string Text { get; set; }
        
        [JsonPropertyName("forwardedMessageId")]
        public int? ForwardedMessageId { get; set; }
        [JsonPropertyName("repliedMessageId")]
        public int? RepliedMessageId { get; set; }
        [JsonPropertyName("pinnedMessageProperty")]
        public bool? PinnedMessage { get; set; }
        
        [ForeignKey("PrivateChatId")]
        public int? PrivateChatId { get; set; }
        [ForeignKey("GroupChatId")]
        public int? GroupChatId { get; set; }
        
        public bool Mine { get; set; }

        //public bool IsNotice => Text.StartsWith("[Notice]");

        public string CSS => Mine ? "sent" : "received";

        public Message()
        {
            SenderUsername = null;
            LocalDateTime = new DateTime().ToString("MM/dd/yyyy h:mm tt");
            Text = null;
            ForwardedMessageId = null;
            RepliedMessageId = null;
            PinnedMessage = null;
        }

        public Message(string senderUsername,string receiverUsername,String text){
            SenderUsername=senderUsername;
            ReceiverUsername = receiverUsername;
            LocalDateTime=DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            Text=text;
        }
        
        public Message(int groupChatId,string senderUsername,string receiverUsername,String text){
            SenderUsername=senderUsername;
            GroupChatId = groupChatId;
            PrivateChatId = null;
            ReceiverUsername = receiverUsername;
            LocalDateTime=DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            Text=text;
        }
        
        public Message(string senderUsername,string receiverUsername,String text,int privateChatId){
            SenderUsername=senderUsername;
            PrivateChatId = privateChatId;
            GroupChatId = null;
            ReceiverUsername = receiverUsername;
            LocalDateTime=DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            Text=text;
        }
        public Message(string senderUsername,String text){
            SenderUsername=senderUsername;
            ReceiverUsername = null;
            LocalDateTime=DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            Text=text;
        }
        
        public Message(string senderUsername, String text, bool mine){
            SenderUsername=senderUsername;
            ReceiverUsername = null;
            LocalDateTime=DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            Text=text;
        }


    }
}