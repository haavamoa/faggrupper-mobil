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
            var viewModelLocator = new ViewModelPageLocator(serviceRegistry);
            serviceRegistry.Register<ViewModelPageLocator>(s => viewModelLocator, new PerContainerLifetime());
            serviceRegistry.Register<MainViewModel>();
            serviceRegistry.Register<IFriendsService, FriendsService>();
            serviceRegistry.Register<HttpClient>();
            serviceRegistry.Register<INavigationService, NavigationService>();
            
            //Register pages that should be navigateable
            viewModelLocator.Register<FriendDetailViewModel, FriendDetailPage>();
            
        }
    }
}