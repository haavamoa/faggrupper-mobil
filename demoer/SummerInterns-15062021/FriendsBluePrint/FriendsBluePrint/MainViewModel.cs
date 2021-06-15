using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FriendsBluePrint
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            AddFriendCommand = new Command<string>(AddFriend);
        }

        public Command AddFriendCommand { get; set; }
        public ObservableCollection<string> Friends { get; } = new ObservableCollection<string>();

        private void AddFriend(string friendName)
        {
            if (!string.IsNullOrEmpty(friendName))
            {
                Friends.Add(friendName);    
            }
        }
    }
}