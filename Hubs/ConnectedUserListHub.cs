using Microsoft.AspNetCore.SignalR;
using SignalrChatAppSecondAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrChatAppSecondAttempt.Hubs
{
    public class ConnectedUserListHub:Hub
    {
        //public override async Task OnConnectedAsync()
        //{
        //    ListUsers.UserConnectedIds.Add(Context.ConnectionId);
        //     await base.OnConnectedAsync();
        //}

        //public override Task OnConnectedAsync()
        //{
        //    ListUsers.UserConnectedIds.Add(Context.ConnectionId);
        //    return base.OnConnectedAsync();
        //}


        //public override Task OnDisconnectedAsync(Exception exception)
        //{


        //    var connection = ListUsers.UserConnectedIds.FirstOrDefault(x => x == Context.ConnectionId);

        //    if (connection != null)
        //    {
        //        ListUsers.UserConnectedIds.Remove(connection);
        //    }

        //    ListUsers.UserConnectedIds.Remove(Context.ConnectionId);
        //    return base.OnDisconnectedAsync(exception);


        //    public List<string> GetAllActiveConnections()
        //    {
        //        return CurrentConnections.ToList();
        //    }
        //}





        //public static List<string> ConnectedList = new List<string>();

        //public override Task OnConnectedAsync()
        //{
        //    var id = Context.ConnectionId;
        //    ConnectedList.Add(id);

        //    return base.OnConnectedAsync();
        //}

        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    var connection = ConnectedList.FirstOrDefault(x => x == Context.ConnectionId);

        //    if (connection != null)
        //    {
        //        ConnectedList.Remove(connection);
        //    }

        //    return base.OnDisconnectedAsync(exception);
        //}


        ////return list of all active connections
        //public List<string> GetAllActiveConnections()
        //{
        //    return ConnectedList.ToList();
        //}
    }
}
