using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;
using Owin;
using System.Diagnostics;


namespace WebAppSignalR3
{
   public class MyHub : Hub //signalR
   {
      public void Send(string name, string message)
      {
         Debug.WriteLine("On send..." + message);
         Clients.All.addMessage(name, message);
      }
   }

   public class Startup //ownin
   {
      public void Configuration(IAppBuilder app)
      {
         Debug.WriteLine("Startup configuration kicked off... in Startup class" );
         app.UseCors(CorsOptions.AllowAll); //critical if independent many other client (javascript)
         app.MapSignalR();

      }
   }
}