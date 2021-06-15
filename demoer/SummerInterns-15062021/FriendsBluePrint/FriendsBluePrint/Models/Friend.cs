namespace FriendsBluePrint.Models
{
    public class Friend
    {
        public Friend(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}