using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<Task> RemoveUser(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5003/User/"+userId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }


        public async Task<Task> PromoteUser(int groupId, int participantId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            Participant participant= GetParticipants(groupId).Result.FirstOrDefault(participant => participant.Id == participantId);
            string participantAsJson = JsonSerializer.Serialize(participant != null && (participant.Admin=true));
            StringContent content = new StringContent(
                participantAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("https://localhost:5003/ParticipantServer/", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            return Task.CompletedTask;
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

        public async Task<IList<Chat>> UserChats(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5003/Chat/"+userId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Chat> chats = JsonSerializer.Deserialize<List<Chat>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return chats;
        }

        public async Task<IList<Participant>> GetParticipants(int groupId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5003/ParticipantServer/Group/"+groupId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Participant> participants = JsonSerializer.Deserialize<List<Participant>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            

            return participants;
        }

        public async Task<IList<Message>> GetPrivateMessages(int chatId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5003/MessageServer/PrivateChat/{chatId}").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Message> messages = JsonSerializer.Deserialize<List<Message>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return messages;
        }

        public async Task<IList<Message>> GetGroupMessages(int groupId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5003/MessageServer/Group/{groupId}").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Message> messages = JsonSerializer.Deserialize<List<Message>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (messages != null)
            {
                messages = messages.Where(message => message.GroupChatId==groupId).ToList();

                return messages;
            }

            return null;
        }

        public async Task<Message> GetMessage(int messageId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("https://localhost:5003/MessageServer/"+messageId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Message message = JsonSerializer.Deserialize<Message>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return message;
        }

        public async Task<Task> UpdateMessage(Message message)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            string messageAsJson = JsonSerializer.Serialize(message);
            StringContent content = new StringContent(
                messageAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("https://localhost:5003/MessageServer", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> RemoveMessage(int messageId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5003/MessageServer/"+messageId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> AddFriendship(string user, string friendToAdd, bool closeFriend)
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
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/User/"+user, content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }

        public async Task<Task> RemoveFriend(int friendshipId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5003/FriendshipServer/"+friendshipId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
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
            HttpResponseMessage response = await client.PostAsync("https://localhost:5003/GroupChatServer", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }

        public async Task<Task> UpdateGroup(GroupChat groupChat)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            string groupChatAsJson = JsonSerializer.Serialize(groupChat);
            StringContent content = new StringContent(
                groupChatAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("https://localhost:5003/GroupChatServer", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> AddParticipant(Participant participant)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            string participantAsJson = JsonSerializer.Serialize(participant);
            StringContent content = new StringContent(
                participantAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("https://localhost:5003/ParticipantServer", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> UpdateParticipant(Participant participant)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            string groupChatAsJson = JsonSerializer.Serialize(participant);
            StringContent content = new StringContent(
                groupChatAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PutAsync("https://localhost:5003/ParticipantServer", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> RemoveParticipant(int participantId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5003/ParticipantServer/"+participantId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> ForwardMessage(Message message,int forwardedMessageId)
        {
            message.ForwardedMessageId = forwardedMessageId;
            await SendMessage(message);
            return Task.CompletedTask;
        }

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
            HttpResponseMessage response = await client.PostAsync("https://localhost:5003/MessageServer", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }

        public async Task<Task> PinMessage(int messageId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using HttpClient client = new HttpClient(clientHandler);


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            Message message = GetMessage(messageId).Result;
            message.PinnedMessage = true;
            string groupChatAsJson = JsonSerializer.Serialize(message);
            StringContent content = new StringContent(
                groupChatAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("https://localhost:5003/MessageServer", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }
    }
}