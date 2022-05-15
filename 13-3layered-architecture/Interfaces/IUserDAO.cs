﻿using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IUserDAO
    {
        void Add(User user);
        void Remove(User user);
        List<User> GetAll();
        void AddReward(User user, Reward reward);
        void RemoveReward(User user, Reward reward);
        void Update(User user, string firstName, string lastName, DateTime birthdate);
    }
}
