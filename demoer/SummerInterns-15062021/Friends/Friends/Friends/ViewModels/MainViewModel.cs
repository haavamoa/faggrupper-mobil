using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Extensions;
using Friends.Models;
using Friends.Services;
using Xamarin.Forms;

namespace Friends.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IFriendsService m_friendsService;
        private readonly IPlatformService m_platformService;
        private readonly INavigationService m_navigationService;
        private string m_newFriendName;
        private bool m_isBusy;

        public MainViewModel(IFriendsService friendsService, 
            IPlatformService platformService, 
            INavigationService navigationService)
        {
            m_friendsService = friendsService;
            m_platformService = platformService;
            m_navigationService = navigationService;
            AddFriendCommand = new Command(AddFriend);
            NavigateToFriendDetailCommand = new Command<Friend>(NavigateToFriendDetail);
        }

        private async void NavigateToFriendDetail(Friend friend)
        {
            await m_navigationService.NavigateTo<FriendDetailViewModel>(viewModel => viewModel.BeforeNavigation(friend));
        }

        public async Task Initialize()
        {
            IsBusy = true;
            var friends = await m_friendsService.GetAllFriends();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
            
            m_platformService.DoSomething();
            IsBusy = false;
        }

        public bool IsBusy
        {
            get => m_isBusy;
            set => PropertyChanged?.RaiseWhenSet(ref m_isBusy, value);
        }

        public ICommand AddFriendCommand { get; }

        public ICommand NavigateToFriendDetailCommand { get; }

        public ObservableCollection<Friend> Friends { get; set; } = new ObservableCollection<Friend>();

        public string NewFriendName
        {
            get => m_newFriendName;
            set => PropertyChanged?.RaiseWhenSet(ref m_newFriendName, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddFriend()
        {
            Friends.Add(new Friend(){ Name = new Name(){ First = NewFriendName}});
            NewFriendName = string.Empty;
        }
    }
}