using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IRewardDAO
    {
        void Add(Reward reward);
        void Remove(Reward reward);
        List<Reward> GetAll();
        void Update(Reward reward);
    }
}
