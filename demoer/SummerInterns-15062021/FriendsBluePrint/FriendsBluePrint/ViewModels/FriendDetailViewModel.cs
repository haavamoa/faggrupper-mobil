using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DIPS.Xamarin.UI.Extensions;
using FriendsBluePrint.Models;
using FriendsBluePrint.Services;

namespace FriendsBluePrint.ViewModels
{
    public class FriendDetailViewModel : INotifyPropertyChanged, IViewModel
    {
        private Friend m_friend;

        public Friend Friend
        {
            get => m_friend;
            set => PropertyChanged.RaiseWhenSet(ref m_friend, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}