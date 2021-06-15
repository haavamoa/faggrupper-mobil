using FriendsBluePrint.iOS.Services;
using FriendsBluePrint.Services.Platform;
using LightInject;

namespace FriendsBluePrint.iOS
{
    public class iOSCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IMyPlatformService, MyPlatformService>();
        }
    }
}