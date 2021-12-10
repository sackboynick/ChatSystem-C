using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Entities
{
    public class PrivateChat:Chat,IComparer<Chat>
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("participant1")]
        public string Participant1 { get; set; }
        [Required]
        [JsonPropertyName("participant2")]
        public string Participant2 { get; set; }


        public PrivateChat()
        {
            Participant1 = null;
            Participant2 = null;
        }
        public PrivateChat(string participant1,string participant2){
            Participant1=participant1;
            Participant2=participant2;
        }


        public int Compare(Chat? x, Chat? y)
        {
            if (x != null)
                if (y != null)
                    return x.Messages.Last().LocalDateTime.CompareTo(y.Messages.Last().LocalDateTime);
            return 0;
        }
    }
}