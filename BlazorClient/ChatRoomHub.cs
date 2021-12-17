using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using BlazorClient.Data;
using BlazorClient.ViewModels;
using DataAccess.Persistence;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorClient
{
    [Authorize]
    public class ChatRoomHub : Hub
    {

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        /*public void SendChatMessage(string who, string message)
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
        }*/

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }

    }
}
