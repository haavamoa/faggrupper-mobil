using Friends.Services;
using LightInject;

namespace Friends.Android
{
    public class AndroidCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPlatformService, AndroidPlatformService>();
        }
    }

    public class AndroidPlatformService : IPlatformService
    {
        public void DoSomething()
        {
            //Do something for Android
        }
    }
}