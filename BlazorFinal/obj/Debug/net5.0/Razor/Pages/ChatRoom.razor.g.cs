#pragma checksum "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc39c4dd60d5d83621d2a0460d7c33f65bd59a12"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorFinal.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/_Imports.razor"
using BlazorFinal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
using BlazorFinal;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chatroom")]
    public partial class ChatRoom : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Chat</h1>\n<hr>");
#nullable restore
#line 9 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
 if (!_isChatting)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "type", "button");
            __builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                     Chat

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(4, "<span class=\"oi oi-chat\" aria-hidden=\"true\"></span> Chat!");
            __builder.CloseElement();
#nullable restore
#line 12 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"

    // Error messages
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
     if (_message != null)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "invalid-feedback");
            __builder.AddContent(7, 
#nullable restore
#line 16 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                       _message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\n        ");
            __builder.OpenElement(9, "small");
            __builder.AddAttribute(10, "id", "emailHelp");
            __builder.AddAttribute(11, "class", "form-text text-muted");
            __builder.AddContent(12, 
#nullable restore
#line 17 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                                            _message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 18 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
     
}
else
{
    // banner to show current user

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "alert alert-secondary mt-4");
            __builder.AddAttribute(15, "role", "alert");
            __builder.AddMarkupContent(16, "<span class=\"oi oi-person mr-2\" aria-hidden=\"true\"></span>\n        ");
            __builder.OpenElement(17, "span");
            __builder.AddContent(18, "You are connected as ");
            __builder.OpenElement(19, "b");
            __builder.AddContent(20, 
#nullable restore
#line 25 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                       _username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\n        ");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "class", "btn btn-sm btn-warning ml-md-auto");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                                                     DisconnectAsync

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "Disconnect");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 28 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
    // display messages

#line default
#line hidden
#nullable disable
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "id", "scrollbox");
#nullable restore
#line 30 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
         foreach (var item in _messages)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
             if (item.IsNotice)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "alert alert-info");
            __builder.AddContent(30, 
#nullable restore
#line 34 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                               item.Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 35 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", 
#nullable restore
#line 38 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                             item.CSS

#line default
#line hidden
#nullable disable
            );
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "user");
            __builder.AddContent(35, 
#nullable restore
#line 39 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                       item.Username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\n                    ");
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", "msg");
            __builder.AddContent(39, 
#nullable restore
#line 40 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                      item.Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 42 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
             
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(40, "<hr>\n        ");
            __builder.OpenElement(41, "textarea");
            __builder.AddAttribute(42, "class", "input-lg");
            __builder.AddAttribute(43, "placeholder", "enter your comment");
            __builder.AddAttribute(44, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 45 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                                                            _newMessage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(45, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _newMessage = __value, _newMessage));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\n        ");
            __builder.OpenElement(47, "button");
            __builder.AddAttribute(48, "class", "btn btn-default");
            __builder.AddAttribute(49, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 46 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
                                                    () => SendAsync(_newMessage)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(50, "Send");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 48 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "/Users/henrikkoster/Documents/CookAway/ChatSystem-C/BlazorFinal/Pages/ChatRoom.razor"
       
    // flag to indicate chat status
    private bool _isChatting = false;

    // name of the user who will be chatting
    private string _username = "hennyg";

    // on-screen message
    private string _message;

    // new message input
    private string _newMessage;

    // list of messages in chat
    private List<Message> _messages = new List<Message>();

    private string _hubUrl;
    private HubConnection _hubConnection;

    public async Task Chat()
    {
        // check username is valid
        if (string.IsNullOrWhiteSpace(_username))
        {
            _message = "Please enter a name";
            return;
        };

        try
        {
            // Start chatting and force refresh UI.
            _isChatting = true;
            await Task.Delay(1);

            // remove old messages if any
            _messages.Clear();

            // Create the chat client
            string baseUrl = navigationManager.BaseUri;

            _hubUrl = baseUrl.TrimEnd('/') + BlazorChatHub.HubUrl;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_hubUrl)
                .Build();

            _hubConnection.On<string, string>("Broadcast", BroadcastMessage);

            await _hubConnection.StartAsync();

            await SendAsync($"[Notice] {_username} joined chat room.");
        }
        catch (Exception e)
        {
            _message = $"ERROR: Failed to start chat client: {e.Message}";
            _isChatting = false;
        }
    }

    private void BroadcastMessage(string name, string message)
    {
        bool isMine = name.Equals(_username, StringComparison.OrdinalIgnoreCase);

        _messages.Add(new Message(name, message, isMine));

        // Inform blazor the UI needs updating
        StateHasChanged();
    }

    private async Task DisconnectAsync()
    {
        if (_isChatting)
        {
            await SendAsync($"[Notice] {_username} left chat room.");

            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();

            _hubConnection = null;
            _isChatting = false;
        }
    }

    private async Task SendAsync(string message)
    {
        if (_isChatting && !string.IsNullOrWhiteSpace(message))
        {
            await _hubConnection.SendAsync("Broadcast", _username, message);

            _newMessage = string.Empty;
        }
    }

    private class Message
    {
        public Message(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
        }

        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }

        public bool IsNotice => Body.StartsWith("[Notice]");

        public string CSS => Mine ? "sent" : "received";
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
    }
}
#pragma warning restore 1591
