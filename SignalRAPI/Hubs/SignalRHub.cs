using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRAPI.Hubs
{
    public class SignalRHub:Hub
    {
        SignalRContext context=new SignalRContext();

        public async Task SendCategoryCount()
        {
            var value=context.Categories.Count();
            await Clients.All.SendAsync("ReceiverCategoryCount",value);//buradaki gelen degeri cliente gonder
        }
    }
}
