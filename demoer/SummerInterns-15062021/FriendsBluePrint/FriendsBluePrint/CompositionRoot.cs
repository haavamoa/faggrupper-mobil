using System.Net.Http;
using FriendsBluePrint.Services;
using FriendsBluePrint.ViewModels;
using LightInject;

namespace FriendsBluePrint
{
    public class CompositionRoot : ICompositionRoot {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<MainPage>();
            serviceRegistry.Register<MainViewModel>();
            serviceRegistry.Register<IFriendsService, FriendsService>();
            serviceRegistry.Register<HttpClient>();
        }
    }
}