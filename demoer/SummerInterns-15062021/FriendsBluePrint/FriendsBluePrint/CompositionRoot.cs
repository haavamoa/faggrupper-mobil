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
            var viewLookupService = new ViewModelPageLocator(serviceRegistry);
            serviceRegistry.Register<ViewModelPageLocator>(s => viewLookupService, new PerContainerLifetime());
            serviceRegistry.Register<MainViewModel>();
            serviceRegistry.Register<IFriendsService, FriendsService>();
            serviceRegistry.Register<HttpClient>();
            serviceRegistry.Register<INavigationService, NavigationService>();
            
            //Register pages other than main page
            viewLookupService.Register<FriendDetailViewModel, FriendDetailPage>();
        }
    }
}