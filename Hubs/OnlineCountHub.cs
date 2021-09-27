using Microsoft.AspNetCore.SignalR;
using SignalrChatAppSecondAttempt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrChatAppSecondAttempt.Hubs
{
    public class OnlineCountHub:Hub
    {
        //public static List<string> ConnectedUser = new List<string>();
        //public static List<string> CurrentConnections = new List<string>();


        private static int Count = 0;
        public override Task OnConnectedAsync()
        {
            Count++;
            //Trace.TraceInformation("MapHub started. ID: {0}", Context.ConnectionId);

            //ListUsers.UserConnectedIds.Add(Context.ConnectionId);

            //ConnectedUser.Add(Context.ConnectionId);
            //ChatHub chatHub = new ChatHub();
            //chatHub.UserConnectionIds(ConnectedUser);

            //var id = Context.ConnectionId;
            //CurrentConnections.Add(id);


            //ChatHub chatHub = new ChatHub();
            //chatHub.ConnectedUSerIds(CurrentConnections);


            //var id = Context.ConnectionId;
            //CurrentConnections.Add(id);

            base.OnConnectedAsync();
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;


            //var id = Context.ConnectionId;
            //CurrentConnections.Remove(id);

            //ListUsers.UserConnectedIds.Remove(Context.ConnectionId);


            base.OnDisconnectedAsync(exception);
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        //public List<string> GetAllActiveConnections()
        //{
        //    return CurrentConnections.ToList();
        //}

    }
}
