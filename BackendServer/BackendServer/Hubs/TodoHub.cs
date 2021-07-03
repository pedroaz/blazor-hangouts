using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServer.Hubs
{
    public class TodoHub : Hub
    {
        public async Task TodoItemsSync()
        {
            await Clients.All.SendAsync("TodoItemsSync");
        }
    }
}
