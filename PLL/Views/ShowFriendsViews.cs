using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class ShowFriendsViews
    {
        UserService UserService { get; set; }
        FriendService FriendService { get; set; }
        public ShowFriendsViews(UserService userService, FriendService friendService)
        {
            UserService = userService;
            FriendService = friendService;
        }
        public void Show(User user)
        {

            try
            {
                foreach (var f in FriendService.GetFriends(user.Id))
                    Console.WriteLine($"{f.firstname} {f.lastname}");
            }
            catch
            {

            }
        }

    }
}
