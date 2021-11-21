using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class User
    {
        [Key]
        [Required]
        [JsonPropertyName("username")]
        private string username;
        [Required]
        [JsonPropertyName("firstname")]
        private string firstName;
        [Required]
        [JsonPropertyName("lastname")]
        private string lastName;
        [Required]
        [JsonPropertyName("password")]
        private string password;
        [Required]
        [JsonPropertyName("friends")]
        private ICollection<Friendship> friends;
        [Required]
        [JsonPropertyName("chats")]
        private ICollection<Chat> chats;

        public User(string username,string firstName,string lastName,string password,ICollection<Friendship> friends,ICollection<Chat> chats){
            this.username=username;
            this.firstName=firstName;
            this.lastName=lastName;
            this.password=password;
            this.friends=friends;
            this.chats=chats;
        }

        public User(string username,string firstName,string lastName,string password){
            this.username=username;
            this.firstName=firstName;
            this.lastName=lastName;
            this.password=password;
            friends=new List<Friendship>();
            chats=new List<Chat>();
        }

        public string GetUsername() {
            return username;
        }

        public string GetFirstName() {
            return firstName;
        }

        public string GetLastName() {
            return lastName;
        }

        public string GetPassword() {
            return password;
        }

        protected ICollection<Friendship> GetFriends(){
            return friends;
        }
        

        public void AddFriend(string friendUsername,bool closeFriend){
            friends.Add(new Friendship(friendUsername, closeFriend));
            chats.Add(new PrivateChat(username,friendUsername));
        }

        public new bool Equals(Object obj) {
            if(obj != null && !(obj.GetType()==typeof(User)))
                return false;
            return username.Equals(((User) obj)?.username);
        }
        public override string ToString() {
            return "Username: "+username;
        }

        public string ToStringFullName(){
            return ToString()+"\nFirst name: "+firstName+"\nLast name: "+lastName;
        }
    }
}