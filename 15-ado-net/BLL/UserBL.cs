using System;
using System.Collections.Generic;
using Entities;
using Interfaces;

namespace BLL
{
    public class UserBL: IUserBL
    {
        private IUserDAO _userDAO;
        public UserBL(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public List<User> GetAll()
        {
            return _userDAO.GetAll();
        }
        public User Get(int id)
        {
            return _userDAO.Get(id);
        }
        public int Add(User user)
        {
            return _userDAO.Add(user);
        }
        public void Remove(User user)
        {
            _userDAO.Remove(user);
        }

        public void Update(User user)
        {
            _userDAO.Update(user);
        }

        public void AddReward(User user, Reward reward)
        {
            _userDAO.AddReward(user, reward);
        }

        public void RemoveReward(User user, Reward reward)
        {
            _userDAO.RemoveReward(user, reward);
        }
    }
}
