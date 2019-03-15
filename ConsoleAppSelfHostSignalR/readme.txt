works. follow  readme: https://docs.microsoft.com/en-us/aspnet/signalr/overview/deployment/tutorial-signalr-self-host


On Package Manager Console:
for signalR server

Install-Package Microsoft.AspNet.SignalR.SelfHost
Install-Package Microsoft.Owin.Cors

for the client application
Install-Package Microsoft.AspNet.SignalR.JS

Copy the .js files under the Script folder of Server application to the client project Script folder if Network tab shows 404.

1. On server add
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Diagnostics;

For simple client side display: Testi with console.log(). Need F12 for multiple client to see
Can switch to rich display by hooking to other addMessage inline function.
