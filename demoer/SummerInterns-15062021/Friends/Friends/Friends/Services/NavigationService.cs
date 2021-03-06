using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Friends.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ViewModelPageLocator m_viewModelPageLocator;

        public NavigationService(ViewModelPageLocator viewModelPageLocator)
        {
            m_viewModelPageLocator = viewModelPageLocator;
        }
        
        public async Task<TViewModel> NavigateTo<TViewModel>(Action<TViewModel> beforeNavigation = null) where TViewModel : class
        {
            var (viewModel, page) = m_viewModelPageLocator.Lookup<TViewModel>();

            beforeNavigation?.Invoke(viewModel);

            page.BindingContext = viewModel;

            await Application.Current.MainPage.Navigation.PushAsync(page);
            return viewModel;
        }
    }
}