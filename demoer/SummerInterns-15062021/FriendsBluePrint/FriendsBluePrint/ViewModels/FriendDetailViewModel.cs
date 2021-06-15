using System.ComponentModel;
using System.Runtime.CompilerServices;
using DIPS.Xamarin.UI.Extensions;
using FriendsBluePrint.Models;

namespace FriendsBluePrint.ViewModels
{
    public class FriendDetailViewModel : INotifyPropertyChanged
    {
        private Friend m_friend;

        public Friend Friend
        {
            get => m_friend;
            set => PropertyChanged.RaiseWhenSet(ref m_friend, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}