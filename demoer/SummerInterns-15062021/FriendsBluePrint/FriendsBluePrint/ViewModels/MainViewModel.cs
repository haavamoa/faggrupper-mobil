using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Extensions;
using FriendsBluePrint.Models;
using FriendsBluePrint.Services;
using Xamarin.Forms;

namespace FriendsBluePrint.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IFriendsService m_friendsService;
        private bool m_isRefreshing;

        public MainViewModel(IFriendsService friendsService)
        {
            m_friendsService = friendsService;
            AddFriendCommand = new Command<string>(AddFriend);
            RefreshFriendsCommand = new Command(async () =>
            {
                await Refresh();
                IsRefreshing = false;
            });
        }

        public ICommand AddFriendCommand { get; }
        public ICommand RefreshFriendsCommand { get; }
        public ObservableCollection<Friend> Friends { get; } = new ObservableCollection<Friend>();

        public bool IsRefreshing
        {
            get => m_isRefreshing;
            set => PropertyChanged.RaiseWhenSet(ref m_isRefreshing, value);
        }

        private void AddFriend(string friendName)
        {
            try
            {
                var firstAndLastName = friendName.Split(' ');
                var first = string.Empty;
                var last = string.Empty;
                if (firstAndLastName.Length > 1)
                {
                    first = firstAndLastName.First();
                    last = firstAndLastName.Last();
                }else if (firstAndLastName.Length == 1)
                {
                    first = firstAndLastName.First();
                }
                
                if (!string.IsNullOrEmpty(friendName)) Friends.Add(new Friend(){ Name = new Name(){ First = first, Last = last}});
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                App.Current.MainPage.DisplayAlert("Oops!", "Something went wrong, check IDE console", "Ok");
            }
        }

        public async void Initialize()
        {
            IsRefreshing = true;
        }
        
        public async Task Refresh()
        {
            try
            {
                var friends = await m_friendsService.Get();

                if (Friends.Any())
                {
                    Friends.Clear();
                }

                foreach (var friend in friends) Friends.Add(friend);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                App.Current.MainPage.DisplayAlert("Oops!", "Something went wrong, check IDE console", "Ok");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}