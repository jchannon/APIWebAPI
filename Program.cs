using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.SelfHost;
using TinyIoC;

namespace APIWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string _baseAddress = "http://localhost:1234/";

            // Set up server configuration 
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}"
            );

            var container = TinyIoCContainer.Current;
            container.AutoRegister();

           // config.MessageHandlers.Add(new RequireHttpsHandler());
            config.MessageHandlers.Add(new RequireAuthentication(container.Resolve<IUserApiMapper>()));

            HttpSelfHostServer server = null; 
            // Create server 
            server = new HttpSelfHostServer(config);

            // Start listening 
            server.OpenAsync().Wait();
            
            Console.WriteLine("Listening on " + _baseAddress);

            Console.ReadLine();

            if (server != null)
            {
                // Stop listening 
                server.CloseAsync().Wait();
            } 
        }
    }
}
