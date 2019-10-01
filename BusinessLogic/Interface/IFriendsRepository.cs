using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogic.Interface
{
    public interface IFriendsRepository
    {
        //выбор всех пользователей
        IEnumerable<Friend> GetFriends();
        //Проверяем, являются ли два пользователя друзьями
        bool UserAreFriends(int userId, int user2Id);
        //добавление пользователя
        void AddFriend(Friend friend);
        //удаление связи между пользователями
        void DeleteFriend(Friend friend);
    }
}