using System;
using System.Collections.ObjectModel;
using FriendsBluePrint.Services;
using Xamarin.Forms;

namespace FriendsBluePrint.ViewModels
{
    public class MainViewModel
    {
        private readonly IFriendsService m_friendsService;

        public MainViewModel(IFriendsService friendsService)
        {
            m_friendsService = friendsService;
            AddFriendCommand = new Command<string>(AddFriend);
        }

        public Command AddFriendCommand { get; set; }
        public ObservableCollection<string> Friends { get; } = new ObservableCollection<string>();

        private void AddFriend(string friendName)
        {
            if (!string.IsNullOrEmpty(friendName)) Friends.Add(friendName);
        }

        public async void Initialize()
        {
            try
            {
                var friends = await m_friendsService.Get();

                foreach (var friend in friends) Friends.Add(friend.Name);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                App.Current.MainPage.DisplayAlert("Oops!", "Something went wrong, check IDE console", "Ok");
            }
        }
    }
}