using System.Collections.Generic;
using Entities;
using Interfaces;
using System.Linq;
using System;

namespace DAL
{
    public class UserListDAO : IUserDAO
    {
        private readonly List<User> listUser = new List<User>();
        public void Add(User user)
        {
            listUser.Add(user);
        }
        public void Remove(User user)
        {
            listUser.Remove(user);
        }
        public List<User> GetAll()
        {
            return listUser.ToList();
        }
        public void Update(User user)
        {
            for (int i = 0; i < listUser.Count; i++)
            {
                if (listUser[i].Id == user.Id)
                {
                    listUser[i].FirstName = user.FirstName;
                    listUser[i].LastName = user.LastName;
                    listUser[i].Birthdate = user.Birthdate;
                }
            }
        }
        public void AddReward(User user, Reward reward)
        {
            bool isNew = true;

            for (int j = 0; j < user.ListReward.Count; j++)
            {
                if (user.ListReward[j] == reward)
                {
                    isNew = false;
                }
            }

            if (isNew)
            {
                 user.ListReward.Add(reward);
            }
        }
        public void RemoveReward(User user, Reward reward)
        {
            user.ListReward.Remove(reward);
        }
    }
}
