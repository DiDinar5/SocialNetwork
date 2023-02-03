using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendsViews
    {
        UserService userService;
        FriendService friendService;
        public AddFriendsViews(UserService userService,FriendService friendService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }
        public void Show(User user)
        {
            Console.Write("Введите почтовый адрес друга: ");
            string Email = Console.ReadLine();
            try
            {
                friendService.AddFriend(user.Id, Email);
                SuccessMessage.Show("Друг успешно найден!");;
                //user = userService.FindByEmail(user.Email);
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
