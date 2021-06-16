using System;
using Friends.Services;
using Friends.ViewModels;
using LightInject;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Friends
{
    public partial class App : Application
    {
        private readonly MainPage m_mainPage;

        public App(ICompositionRoot platformCompositionRoot)
        {
            InitializeComponent();

            //Container
            Container = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false });
            Container.RegisterFrom<CompositionRoot>();
            Container.RegisterFrom(platformCompositionRoot);

            m_mainPage = Container.GetInstance<MainPage>();
            MainPage = new NavigationPage(m_mainPage);
        }

        public static ServiceContainer Container { get; set; }

        protected override void OnStart()
        {
            ((MainViewModel)m_mainPage.BindingContext).Initialize();
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