﻿using System;
using System.Collections.Generic;
using Entities;
using DAL;
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
        public void Add(User user)
        {
            _userDAO.Add(user);
        }
        public void Remove(User user)
        {
            _userDAO.Remove(user);
        }

        public void Update(User user, string firstName, string lastName, DateTime birthdate)
        {
            _userDAO.Update(user, firstName, lastName, birthdate);
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
