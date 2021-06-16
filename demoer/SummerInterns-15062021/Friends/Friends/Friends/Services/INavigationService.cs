using System;
using System.Threading.Tasks;

namespace Friends.Services
{
    public interface INavigationService
    {
        Task<TViewModel> NavigateTo<TViewModel>(Action<TViewModel> beforeNavigation = null) where TViewModel : class;
    }
}