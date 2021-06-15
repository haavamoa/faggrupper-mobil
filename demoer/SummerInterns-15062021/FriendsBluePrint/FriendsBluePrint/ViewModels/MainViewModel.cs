using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Extensions;
using FriendsBluePrint.Models;
using FriendsBluePrint.Services;
using FriendsBluePrint.Services.Platform;
using Xamarin.Forms;

namespace FriendsBluePrint.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IFriendsService m_friendsService;
        private readonly IMyPlatformService m_myPlatformService;
        private readonly INavigationService m_navigationService;
        private bool m_isRefreshing;

        public MainViewModel(IFriendsService friendsService, IMyPlatformService myPlatformService, INavigationService navigationService)
        {
            m_friendsService = friendsService;
            m_myPlatformService = myPlatformService;
            m_navigationService = navigationService;
            AddFriendCommand = new Command<string>(AddFriend);
            RefreshFriendsCommand = new Command(
                async () =>
                {
                    await Refresh();
                    IsRefreshing = false;
                });
            NavigateToFriendDetailCommand = new Command<Friend>(
                async friend =>
                {
                    await m_navigationService.NavigateTo<FriendDetailViewModel>(viewmodel => viewmodel.Friend = friend);
                });
        }

        public ICommand AddFriendCommand { get; }
        public ObservableCollection<Friend> Friends { get; } = new ObservableCollection<Friend>();

        public bool IsRefreshing
        {
            get => m_isRefreshing;
            set => PropertyChanged.RaiseWhenSet(ref m_isRefreshing, value);
        }

        public ICommand NavigateToFriendDetailCommand { get; }
        public ICommand RefreshFriendsCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

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
                }
                else if (firstAndLastName.Length == 1)
                {
                    first = firstAndLastName.First();
                }

                if (!string.IsNullOrEmpty(friendName)) Friends.Add(new Friend { Name = new Name { First = first, Last = last } });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Application.Current.MainPage.DisplayAlert("Oops!", "Something went wrong, check IDE console", "Ok");
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

                if (Friends.Any()) Friends.Clear();

                foreach (var friend in friends) Friends.Add(friend);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Application.Current.MainPage.DisplayAlert("Oops!", "Something went wrong, check IDE console", "Ok");
            }
            finally
            {
                m_myPlatformService.DoSomething();
            }
        }
    }
}