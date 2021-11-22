using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class User
    {
        [Key]
        public int Id { get; set;}

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
        private ICollection<Friendship> _friends;


        public User()
        {
            username = null;
            firstName = null;
            lastName = null;
            password = null;
            _friends = new List<Friendship>();
        }
        public User(int userId, string username,string firstName,string lastName,string password,ICollection<Friendship> friends)
        {
            Id = userId;
            this.username=username;
            this.firstName=firstName;
            this.lastName=lastName;
            this.password=password;
            this._friends=friends;
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
            return _friends;
        }
        

        public void AddFriend(string friendUsername,bool closeFriend){
            _friends.Add(new Friendship(friendUsername, closeFriend));
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