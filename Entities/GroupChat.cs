using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Entities
{
    public class GroupChat:Chat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }
        [Required]
        [JsonPropertyName("participants")]
        public ICollection<Participant> Participants { get; set; }

        public GroupChat()
        {
            Participants = new List<Participant>();

        }
        public GroupChat(string groupName,string groupCreator)
        {
            GroupName = groupName;
            Participants =new List<Participant> {new(groupCreator,true)};
            Messages.Add(new Message("Server", groupCreator+" just created the group on date "+ DateTime.Now.ToString("MM/dd/yyyy h:mm:ss")));
            Console.WriteLine(groupCreator);
        }

        public bool IsUsernameInGroup(string participant){
            return Participants.FirstOrDefault(participant1 => participant1.Username==participant)!=null;
        }
        
    }
}