using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    /// <summary> 
    /// Сервис по работе с друзьями 
    /// </summary> 
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        /// <summary> 
        /// Добавление пользователя в друзья 
        /// </summary> 
        /// <param name="friendAddData">Введенные данные пользователя, для добавления</param> 
        public void AddFriend(int userId, string friendEmail)
        {
            if (userId<=0 || String.IsNullOrEmpty(friendEmail))
                throw new ArgumentNullException();


            var findFrendEntity = this.userRepository.FindByEmail(friendEmail);
            if (findFrendEntity is null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = userId,
                friend_id = findFrendEntity.id
            };

            if (friendEntity.user_id == friendEntity.friend_id)
                throw new UserNotFoundException();

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
        public List<UserEntity> GetFriends(int userId)
        {
            var friends = new List<UserEntity>();
            foreach (int friendId in friendRepository.FindAllByUserId(userId).Select(fe => fe.friend_id))
            {
                var u = userRepository.FindById(friendId);
                if (u is null)
                    continue;
                friends.Add(u);
            }
            return friends;
        }
    }
}