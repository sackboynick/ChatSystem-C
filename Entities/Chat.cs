using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public abstract class Chat {
        [Required]
        [JsonPropertyName("messages")]
        public ICollection<Message> Messages { get; set; }
        

        public Chat(){
            Messages=new List<Message>();
        }
        
        
    }
}