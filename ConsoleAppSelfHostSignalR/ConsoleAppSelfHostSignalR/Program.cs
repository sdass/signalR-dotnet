using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Diagnostics;

namespace ConsoleAppSelfHostSignalR
{

   //readme: https://docs.microsoft.com/en-us/aspnet/signalr/overview/deployment/tutorial-signalr-self-host
   class Program
   {
      static void Main(string[] args)
      {

         string url = "http://localhost:8099";
         using (WebApp.Start(url))
         {
            Console.WriteLine("server running on {0}", url);
            Console.ReadLine();
         }

      }
   }//class ends

   class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.UseCors(CorsOptions.AllowAll);
         app.MapSignalR();
      }
   }

   public class CustomHub : Hub
   {
      public void Send(string name, string message)
      {
         Debug.WriteLine(">> {0} : {1}", name, message);
         Clients.All.addMessage(name, message + ' ' + DateTime.Now.ToString());
         Debug.WriteLine("<< dispatched");
      }
   }

}//namespace ends
