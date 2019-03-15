using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace SignalRChatServ
{
   public class ChatHub : Hub
   {

      public void Send(string name, string message)
      {
         Debug.WriteLine(">>" + name + " " + message);
         Clients.All.broadcastMessage(name, message); 
      }

      
      public void Hello()
      {
         Clients.All.hello( "ab", "this is hello");
      }

      

      public void Arbitrary(string name )
      {
         Clients.All.arbiter(name + DateTime.Now.ToString());
      }

   
   }
}