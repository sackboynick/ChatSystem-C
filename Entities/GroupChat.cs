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
        [Key]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("participants")]
        public ICollection<Participant> Participants { get; set; }

        public GroupChat()
        {
            Participants = new List<Participant>();

        }
        public GroupChat(string groupCreator)
        {
            Participants =new List<Participant> {new(groupCreator,true)};
            Messages.Add(new Message("Server", Participants.ToList()[0]+" just created the group on date "+ DateTime.Now.ToString("MM/dd/yyyy h:mm tt")));
            Console.WriteLine(groupCreator);
        }

        public bool IsUsernameInGroup(string participant){
            return Participants.FirstOrDefault(participant1 => participant1.Username==participant)!=null;
        }
        
    }
}