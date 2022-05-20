﻿using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IUserDAO
    {
        int Add(User user);
        User Get(int id);
        void Remove(User user);
        List<User> GetAll();
        void AddReward(User user, Reward reward);
        void RemoveReward(User user, Reward reward);
        void Update(User user);
    }
}
