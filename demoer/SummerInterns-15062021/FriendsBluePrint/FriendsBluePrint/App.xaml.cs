using System;
using LightInject;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace FriendsBluePrint
{
    public partial class App : Application
    {
        public App(ICompositionRoot platformCompositionRoot)
        {
            InitializeComponent();

            Container = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false });
            Container.RegisterFrom<CompositionRoot>();
            Container.RegisterFrom(platformCompositionRoot);
            MainPage = new NavigationPage(Container.GetInstance<MainPage>());
        }
        
        public static ServiceContainer Container { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}