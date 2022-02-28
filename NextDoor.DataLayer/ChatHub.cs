using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.DataLayer
{
    public class ChatHub : Hub
    {
        public async Task SendMessage1(string user, string message)               // Two parameters accepted
        {
             await  Clients.All.SendAsync("ReceiveOne", user, message);    // Note this 'ReceiveOne' 
        }

        public void IsTyping(string typer)
        {
            // do stuff with the html
           // SayWhoIsTyping(typer); //call the function to send the html to the other clients
        }

        /*public void SayWhoIsTyping(string typer)
        {
            Clients.All.sayWhoIsTyping(typer);

        }*/
    }
}
