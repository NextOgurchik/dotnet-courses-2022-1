using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Interfaces
{
    public interface IRewardBL
    {
        void Add(Reward reward);
        void Remove(Reward reward);
        List<Reward> GetAll();
        void Update(int rewardId, Reward reward);
    }
}
