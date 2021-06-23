using System;
using System.Threading.Tasks;

namespace FriendsBluePrint.Services
{
    public interface INavigationService
    {
        Task<TViewModel> NavigateTo<TViewModel>(Action<TViewModel> beforeNavigation = null) where TViewModel : IViewModel;
    }
}