using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using DataAccess.Persistence;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorClient
{
    public class ChatRoomHub : Hub
    {
        public const string HubUrl = "/chat";

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public void SendChatMessage(string who, string message)
        {
            var name = Context.User.Identity.Name;
            using var db = new ChatContext();
            var user = db.Users.Find(who);
            if (user == null)
            {
                Console.WriteLine("User not found...");
            }
            else
            {
                db.Entry(user)
                    .Collection(u => u.Connections)
                    .Query()
                    .Where(c => c.Connected)
                    .Load();

                if (user.Connections == null)
                {
                    Console.WriteLine("User is disconnected...");
                }
                else
                {
                    foreach (var connection in user.Connections)
                    {
                        Clients.Client(connection.ConnectionID)
                            .SendAsync(name + ": " + message);
                    }
                }
            }
        }

        // public override Task OnConnectedAsync()
        // {
        //     Console.WriteLine($"{Context.ConnectionId} connected");
        //     return base.OnConnectedAsync();
        // }

        // public override async Task OnDisconnectedAsync(Exception e)
        // {
        //     Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
        //     await base.OnDisconnectedAsync(e);
        // }
        
        public override Task OnConnectedAsync()
        {
            var name = Context.User.Identity.Name;
            using (var db = new ChatContext())
            {
                var user = db.Users
                    .Include(u => u.Connections)
                    .SingleOrDefault(u => u.Username == name);
                
                if (user == null)
                {
                    user = new User
                    {
                        Username = name,
                        Connections = new List<Connection>()
                    };
                    db.Users.Add(user);
                }

                user.Connections.Add(new Connection
                {
                    ConnectionID = Context.ConnectionId,
                    UserAgent = "User-Agent",
                    Connected = true
                });
                db.SaveChanges();
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception e)
        {
            using (var db = new ChatContext())
            {
                var connection = db.Connections.Find(Context.ConnectionId);
                connection.Connected = false;
                db.SaveChanges();
            }
            return base.OnDisconnectedAsync(e);
        }
    }
}