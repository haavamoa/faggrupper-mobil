using Friends.Services;
using Friends.ViewModels;
using LightInject;
using Xamarin.Forms.PlatformConfiguration;

namespace Friends
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<MainPage>();
            serviceRegistry.Register<MainViewModel>();
            var viewLookupService = new ViewModelPageLocator(serviceRegistry);
            serviceRegistry.Register<ViewModelPageLocator>(s => viewLookupService, new PerContainerLifetime());
            serviceRegistry.Register<INavigationService, NavigationService>();
            serviceRegistry.Register<IFriendsService, FriendsService>();

            viewLookupService.Register<FriendDetailViewModel, FriendDetailPage>();
            
        }
    }
}