using System.Collections.Generic;

namespace WinFormsApp1
{
    internal class List
    {
        public static List<User> ListUsers { get; set; }
        public static List<Reward> ListRewards { get; set; }
        public List(List<User> listUsers, List<Reward> listRewards)
        {
            ListUsers = listUsers;
            ListRewards = listRewards;
        }
    }
}