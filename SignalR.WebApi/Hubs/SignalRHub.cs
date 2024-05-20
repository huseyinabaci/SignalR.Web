using Dapper.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.WebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IUnitOfWork unitOfWork;

        public SignalRHub(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task SendStatistic()
        {
            var data = await unitOfWork.Products.GetAllAsync();
            await Clients.All.SendAsync("ReceiveStatistic", data.Count());
        }

        public static int clientCount { get; set; } = 0;
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
