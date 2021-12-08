using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace WebApplication.Data
{
    public class HttpDataRetriever: IData
    {
        public async Task<Task> SendMessage(Message message)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            string userAsJson = JsonSerializer.Serialize(message);
            StringContent content = new StringContent(
                userAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/LogIn", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }

        public async Task<PrivateChat> GetPrivateChat(int chatId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/PrivateChat/"+chatId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            PrivateChat privateChat = JsonSerializer.Deserialize<PrivateChat>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return privateChat;
        }

        public async Task<GroupChat> GetGroupChat(int chatId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Group/"+chatId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            GroupChat groupChat = JsonSerializer.Deserialize<GroupChat>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return groupChat;
        }

        private async Task<Task> UpdateGroup(GroupChat groupChat)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");

            string groupChatAsJson = JsonSerializer.Serialize(groupChat);
            StringContent content = new StringContent(
                groupChatAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PutAsync("https://localhost:5001/Group", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }
        public async void AddParticipantToGroup(int groupId, string userToAdd)
        {
            GroupChat groupChat = GetGroupChat(groupId).Result;
            groupChat.Participants.Add(new Participant(userToAdd,false));
            await UpdateGroup(groupChat);
        }

        public async void RemoveParticipantFromGroup(int groupId, string userToRemove)
        {
            GroupChat groupChat = GetGroupChat(groupId).Result;
            groupChat.Participants.Remove(groupChat.Participants.First(participant => participant.Equals(new Participant(userToRemove,false))));
            await UpdateGroup(groupChat);
        }

        public async void PromoteParticipantToAdmin(int groupId, string userToPromote)
        {
            GroupChat groupChat = GetGroupChat(groupId).Result;
            groupChat.Participants.First(participant => participant.Username==userToPromote).Admin=true;
            await UpdateGroup(groupChat);
        }

        public async Task<Task> CreateGroup(string groupCreator)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");

            GroupChat groupChat = new GroupChat(groupCreator);
            string userAsJson = JsonSerializer.Serialize(groupChat);
            StringContent content = new StringContent(
                userAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/Group?groupCreator=", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }
        

        public async Task<User> GetUser(string username)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/User/"+username).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return user;
        }

        public async Task<Task> AddFriend(string user, string friendToAdd, bool closeFriend)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");

            Friendship friendship = new Friendship(friendToAdd, closeFriend);
            string friendshipAsJson = JsonSerializer.Serialize(friendship);
            StringContent content = new StringContent(
                friendshipAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PutAsync("https://localhost:5001/User/"+user, content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }
    }
}