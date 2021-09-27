using Microsoft.AspNetCore.SignalR;
using SignalrChatAppSecondAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrChatAppSecondAttempt.Hubs
{
    public class ChatHub:Hub
    {

        public string GetConnectionId() => Context.ConnectionId;


        private static int Count = 0;

        public static List<string> CurrentConnections = new List<string>();

        
        //public static  List<UserConnections> CurrentConnections = new List<UserConnections>();



        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendToUser(string user, string receiverConnectionId, string message)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", user, message);
        }





       
        public List<string> GetAllActiveConnections()
        {

            if (Count == 0)
            {
                CurrentConnections.Add(Context.ConnectionId);

                Count++;
                return CurrentConnections.ToList();
                
            }
            if (Count >= 1)
            {

                
                if (CurrentConnections.Count >=1)
                {

                    CurrentConnections.Remove(Context.ConnectionId);
                    CurrentConnections.Add(Context.ConnectionId);


                    Count++;

                    return CurrentConnections.ToList();
                }
                else
                {
                    CurrentConnections.Add(Context.ConnectionId);
                    Count++;
                    return CurrentConnections.ToList();
                }
            } 
            
            return null;

          


            
            //if(Count==0)
            //{
            //    CurrentConnections.Add(Context.ConnectionId);
            //}
            //if (Count >= 1)
            //{

            //    CurrentConnections.Remove(Context.ConnectionId);
            //    CurrentConnections.Add(Context.ConnectionId);
            //}
            //Count++;
          
            //return CurrentConnections.ToList();
            

            //List<string> Existingid = new List<string>();

            //var chak = CurrentConnections.Where(m => m.ConnectectionId == Context.ConnectionId).FirstOrDefault();
            //if (chak==null)
            //{
            //    CurrentConnections.Add(new UserConnections
            //    {

            //        ConnectectionId = Context.ConnectionId
            //    });
            //}
            //return CurrentConnections.ToList();



            //CurrentConnections.Add(Context.ConnectionId);

            //if (CurrentConnections.Any())
            //{



            //    return CurrentConnections.ToList();
            //}



            //if(CurrentConnections.Any()==Context.ConnectionId.Any())
            //{

            //    return null;
            //}

            //if (Existingid.Any()==CurrentConnections.Any())
            //{
            ////    return null;
            ////}

            //else
            //{
            //    //Existingid = CurrentConnections;



            //}



            //return CurrentConnections.ToList();



            //List<string> ExistringIds = new List<string>();

            //ExistringIds = CurrentConnections;

            //if (ExistringIds.Count==CurrentConnections.Count)

            //CurrentConnections.Add(new UserConnections
            //{

            //    ConnectectionId = Context.ConnectionId

            //});
            //var cout = 0;
            //if(cout<=2)
            //{
            //    var id = Context.ConnectionId;

            //    CurrentConnections.Add(id);
            //    return CurrentConnections.ToList();

            //}
            //cout++;

            //else
            //{
            //    return CurrentConnections.ToList();

            //}





            //var id = Context.ConnectionId;

            //if (CurrentConnections.Count(x => x.ConnectectionId == id) == 0)
            //{
            //    CurrentConnections.Add(new UserConnections { ConnectectionId = id });
            //}

            //var item = CurrentConnections.FirstOrDefault(x => x.ConnectectionId == Context.ConnectionId);

            //ConnectedUSerIds(CurrentConnections);



            //return CurrentConnections.ToList();
            //List<string> existingUserConnectionIds = CurrentConnections;
            //if(existingUserConnectionIds.Count==CurrentConnections.Count)
            //{
            //    return CurrentConnections.ToList();
            //}

            //else
            //{
            //    return null;
            //}

            //if (CurrentConnections==)
            //{
            //    return null;
            //}



            //return CurrentConnections;



        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;


            //var id = Context.ConnectionId;
            //CurrentConnections.Remove(id);

            //ListUsers.UserConnectedIds.Remove(Context.ConnectionId);

            CurrentConnections.Remove(Context.ConnectionId);
            base.OnDisconnectedAsync(exception);
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }






    }
}
