using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Blazor.Data
{
    public class DataRetriever : IData
    {
        public async Task<User> GetUser(string username)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5003/UserServer/"+username).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return user;
        }

        public Task RemoveUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task PromoteUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task AddFriendToGroup(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Friendship>> UserFriendships(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5003/FriendOf/"+userId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Friendship> friendships = JsonSerializer.Deserialize<List<Friendship>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return friendships;
        }

        public Task<IList<Chat>> UserChats(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Participant>> GetParticipants(int groupId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Message>> GetPrivateMessages(int chatId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Message>> GetGroupMessages(int groupId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Message> GetMessage(int messageId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveMessage(int messageId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddFriendship(Friendship friendship)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFriend(int friendshipId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Friendship> GetFriendship(int friendshipId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5003/FriendshipServer/"+friendshipId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Friendship friendship = JsonSerializer.Deserialize<Friendship>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return friendship;
        }

        public Task CreateGroup(string groupCreator)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGroup(GroupChat groupChat)
        {
            throw new System.NotImplementedException();
        }

        public Task AddParticipant(Participant participant)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateParticipant(Participant participant)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveParticipant(int participantId)
        {
            throw new System.NotImplementedException();
        }

        public Task ForwardMessage(string toUser, int messageId)
        {
            throw new System.NotImplementedException();
        }

        public Task PinMessage(int messageId)
        {
            throw new System.NotImplementedException();
        }
    }
}