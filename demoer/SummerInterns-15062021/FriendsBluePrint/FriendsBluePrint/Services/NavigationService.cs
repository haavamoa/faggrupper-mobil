using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FriendsBluePrint.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ViewModelPageLocator m_viewModelPageLocator;

        public NavigationService(ViewModelPageLocator viewModelPageLocator)
        {
            m_viewModelPageLocator = viewModelPageLocator;
        }
        
        public async Task<TViewModel> NavigateTo<TViewModel>(Action<TViewModel> beforeNavigation = null) where TViewModel : IViewModel
        {
            var (viewModel, page) = m_viewModelPageLocator.Lookup<TViewModel>();

            beforeNavigation?.Invoke(viewModel);

            page.BindingContext = viewModel;

            //Run initialize
            _ = viewModel.Initialize();
            await Application.Current.MainPage.Navigation.PushAsync(page);
            
            
            return viewModel;
        }
    }

    public interface IViewModel
    {
        Task Initialize();
    }
}