using Friends.Services;
using LightInject;

namespace Friends.iOS
{
    public class iOSCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPlatformService, iOSPlatformService>();
        }
    }

    public class iOSPlatformService : IPlatformService
    {
        public void DoSomething()
        {
            //DO something for iOS
        }
    }
}