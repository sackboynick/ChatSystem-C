using System;
using System.Collections.Generic;

namespace Entities
{
    public class GroupChat:Chat
    {
        private readonly List<string> _participants;
        private readonly string[] admins;

        public GroupChat(String groupCreator, string[] admins)
        {
            this.admins = admins;
            this._participants =new List<string>();
            this._participants.Add(groupCreator);
            this.GetMessages().Add(new Message("Server", _participants[0]+" just created the group on date "+ DateTime.Now.ToString("MM/dd/yyyy h:mm tt")));
            this.admins[0]=groupCreator;
        }

        public bool IsUsernameInGroup(String participant){
            return _participants.Contains(participant);
        }

        
        public List<Message> GetMessages() {
            return base.GetMessages();
        }
    }
}