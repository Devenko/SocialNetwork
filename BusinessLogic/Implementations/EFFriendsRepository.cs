using BusinessLogic.Interface;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace BusinessLogic.Implementations
{
    public class EFFriendsRepository : IFriendsRepository
    {
        private EFDbContext context;
        public EFFriendsRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Friend> GetFriends()
        {
            return context.Friends;
        }
        //сравниваем являются ли два пользователя друзьями
        public bool UserAreFriends(int userId, int user2Id)
        {
            return context.Friends.Count(x=>x.UserId == userId && x.FriendId == user2Id) != 0;
        }
        //добавление друга
        public void AddFriend(Friend friend)
        {
            context.Friends.Add(friend);
            context.SaveChanges();
        }
        //удаление друга
        public void DeleteFriend(Friend friend)
        {
            context.Friends.Remove(friend);
            context.SaveChanges();
        }
    }
}
