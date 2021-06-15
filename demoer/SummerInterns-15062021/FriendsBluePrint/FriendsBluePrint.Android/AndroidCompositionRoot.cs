using FriendsBluePrint.Android.Services;
using FriendsBluePrint.Services.Platform;
using LightInject;

namespace FriendsBluePrint.Android
{
    public class AndroidCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IMyPlatformService, MyPlatformService>();
        }
    }
}