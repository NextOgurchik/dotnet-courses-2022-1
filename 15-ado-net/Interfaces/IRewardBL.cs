using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Interfaces
{
    public interface IRewardBL
    {
        int Add(Reward reward);
        Reward Get(int id);
        void Remove(Reward reward);
        List<Reward> GetAll();
        void Update(Reward reward);
    }
}
