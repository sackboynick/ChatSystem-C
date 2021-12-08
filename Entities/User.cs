using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set;}
        [Required]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set;}
        [Required]
        [JsonPropertyName("lastname")]
        public string LastName { get; set;}
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set;}
        [Required]
        [JsonPropertyName("friends")]
        public virtual ICollection<Friendship> Friends { get; set;}


        public User()
        {
            Id = 0;
            Username = null;
            FirstName = null;
            LastName = null;
            Password = null;
            Friends = new Collection<Friendship>();
        }
        public User(int userId, string username,string firstName,string lastName,string password,ICollection<Friendship> friends)
        {
            Id = userId;
            Username=username;
            FirstName=firstName;
            LastName=lastName;
            Password=password;
            Friends=friends;
        }
  

        public void AddFriend(Friendship friendship){
            Friends.Add(friendship);
        }

        public new bool Equals(Object obj) {
            if(obj != null && !(obj.GetType()==typeof(User)))
                return false;
            return Username.Equals(((User) obj)?.Username);
        }
        public override string ToString() {
            return "Username: "+Username;
        }

        public string ToStringFullName(){
            return ToString()+"\nFirst name: "+FirstName+"\nLast name: "+LastName;
        }
    }
}