using System;
using System.Collections.Generic;
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
            HttpResponseMessage response = await client.PostAsync("http://localhost:5001/Message", content).ConfigureAwait(false);
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
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/PrivateChat/"+chatId).ConfigureAwait(false);
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
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Group/"+chatId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            GroupChat groupChat = JsonSerializer.Deserialize<GroupChat>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return groupChat;
        }
        
        public async Task<Task> AddParticipantToGroup(Participant participant)
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
            HttpResponseMessage response = await client.PostAsync("http://localhost:5001/Participant", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> RemoveParticipantFromGroup(int participantId)
        {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using HttpClient client = new HttpClient(clientHandler);
            
            
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
                HttpResponseMessage response = await client.DeleteAsync("http://localhost:5001/Participant/"+participantId).ConfigureAwait(false);
                if(!response.IsSuccessStatusCode)
                    throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
                return Task.CompletedTask;
        }

        public async Task<Task> PromoteParticipantToAdmin(Participant participant)
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
            HttpResponseMessage response = await client.PutAsync("http://localhost:5001/Participant", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }
        

        public async Task<Task> CreateGroup(GroupChat groupChat)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");

            string userAsJson = JsonSerializer.Serialize(groupChat);
            StringContent content = new StringContent(
                userAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:5001/Group", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }
        

        public async Task<User> GetUser(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/User/"+userId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return user;
        }
        
        public async Task<User> GetUserFromUsername(string username)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/User/Username/"+username).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return user;
        }

        public async Task<Task> AddFriendship(Friendship friendship)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");

            string friendshipAsJson = JsonSerializer.Serialize(friendship);
            StringContent content = new StringContent(
                friendshipAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:5001/Friendship/", content).ConfigureAwait(false);
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
            
                
            HttpResponseMessage response = await client.DeleteAsync("http://localhost:5001/Friendship/"+friendshipId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Task> UpdateFriendship(Friendship friendship)
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

            Friendship friendship1 = friendship;
            string friendshipAsJson = JsonSerializer.Serialize(friendship1);
            StringContent content = new StringContent(
                friendshipAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("http://localhost:5001/Friendship", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
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

            string groupChatAsJson = JsonSerializer.Serialize(message);
            StringContent content = new StringContent(
                groupChatAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("http://localhost:5001/Message", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }

        public async Task<Message> GetMessage(int messageId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Message/"+messageId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Message message = JsonSerializer.Deserialize<Message>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return message;
        }

        public async Task<Participant> GetParticipant(int participantId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Participant/"+participantId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Participant participant = JsonSerializer.Deserialize<Participant>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return participant;
        }

        public async Task<Task> UpdateUser(User user)
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

            string userAsJson = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                userAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response =
                await client.PutAsync("http://localhost:5001/User", content).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }
        

        public async Task<Task> RemoveUser(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
            HttpResponseMessage response = await client.DeleteAsync("http://localhost:5001/User/"+userId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            return Task.CompletedTask;
        }



        public async Task<List<Friendship>> GetAllFriendsOfUser(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Friendship/").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Friendship> friendships = JsonSerializer.Deserialize<List<Friendship>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (friendships != null)
            {
                friendships = friendships.Where(friendship => friendship.UserId == userId || friendship.FriendUserId==userId).ToList();

                return friendships;
            }

            return null;
        }

        public async Task<List<PrivateChat>> GetAllUserPrivateChats(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/PrivateChat/").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<PrivateChat> privateChats = JsonSerializer.Deserialize<List<PrivateChat>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            string username = GetUser(userId).Result.Username;
            if (privateChats != null)
            {
                privateChats = privateChats.Where(privateChat => privateChat.Participant1 == username || privateChat.Participant2 == username).ToList();

                return privateChats;
            }

            return null;
        }

        public async Task<List<GroupChat>> GetAllUserGroupChats(int userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Group/").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<GroupChat> groupChats = JsonSerializer.Deserialize<List<GroupChat>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            string username = GetUser(userId).Result.Username;
            if (groupChats != null)
            {
                groupChats = groupChats.Where(groupChat => groupChat.IsUsernameInGroup(username)).ToList();

                return groupChats;
            }

            return null;
        }

        public async Task<List<Message>> GetAllChatMessages(int chatId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/PrivateChat/"+chatId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            PrivateChat privateChat = JsonSerializer.Deserialize<PrivateChat>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (privateChat != null)
            {
                List<Message> messages = privateChat.Messages.ToList();
                messages = messages.Where(message => message.PrivateChatId==chatId).ToList();

                return messages;
            }

            return null;
        }

        public async Task<List<Message>> GetAllGroupMessages(int groupId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Message/").ConfigureAwait(false);
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

        public async Task<List<Participant>> GetAllGroupParticipants(int groupId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Participant/").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<Participant> participants = JsonSerializer.Deserialize<List<Participant>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (participants != null)
            {
                participants = participants.Where(participant => participant.GroupChatId==groupId).ToList();

                return participants;
            }

            return null;
        }



        public async Task<List<Chat>> GetAllUserChats(int userId)
        {
            List<PrivateChat> privateChats = GetAllUserPrivateChats(userId).Result;
            List<GroupChat> groupChats = GetAllUserGroupChats(userId).Result;
            List<Chat> chats = privateChats.Union<Chat>(groupChats).ToList();

            return chats;
        }

        public async Task<Task> RemoveMessage(int messageId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
            HttpResponseMessage response = await client.DeleteAsync("http://localhost:5001/Message/"+messageId).ConfigureAwait(false);
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
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/Friendship/"+friendshipId).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Friendship friendship = JsonSerializer.Deserialize<Friendship>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return friendship;
        }

        public async Task<List<User>> GetAllUsers()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/User/").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            List<User> users = JsonSerializer.Deserialize<List<User>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            return users;
        }
    }
}