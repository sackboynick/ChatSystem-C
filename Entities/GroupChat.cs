using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Entities
{
    public class GroupChat:Chat
    {
        [Required]
        [JsonPropertyName("participants")]
        public ICollection<string> Participants { get; set; }
        [Required]
        [JsonPropertyName("admins")]
        public ICollection<string> Admins { get; set; }

        public GroupChat()
        {
            Participants = new Collection<string>();
            Admins = new Collection<string>();

        }
        public GroupChat(String groupCreator)
        {
            Admins = new Collection<string>();
            Admins.Add(groupCreator);
            Participants =new List<string> {groupCreator};
            _messages.Add(new Message("Server", Participants.ToList()[0]+" just created the group on date "+ DateTime.Now.ToString("MM/dd/yyyy h:mm tt")));
        }

        public bool IsUsernameInGroup(String participant){
            return Participants.Contains(participant);
        }
        
    }
}