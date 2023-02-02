using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();

        }
        //public IEnumerable<Friends> GetIncomingRequestByUserId(int recipientId)
        //{
        //    var friends = new List<Friends>();

        //    friendRepository.FindAllByUserId(recipientId).ToList().ForEach(m =>
        //    {
        //        var senderUserEntity = userRepository.FindById(m.friend_id);

        //        friends.Add(new Friends(m.id, m.friend_id, m.user_id));
        //    });

        //    return friends;
        //}
        public void AddFriend(Friends friends,FriendsEmail friendsEmail)
        {
            if (friends.Id == 0)
                throw new UserNotFoundException();
            if(friends.FriendId == 0)
                throw new UserNotFoundException();
            if(friends.UserId == 0)
                throw new UserNotFoundException();
            if (String.IsNullOrEmpty(friendsEmail.Email))
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                id = friends.Id,
                user_id = friends.UserId,
                friend_id = friends.FriendId
            };
        }
    }    
    
}
