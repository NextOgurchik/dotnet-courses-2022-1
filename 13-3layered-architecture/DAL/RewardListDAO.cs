using System.Collections.Generic;
using Entities;
using Interfaces;
using System.Linq;

namespace DAL
{
    public class RewardListDAO : IRewardDAO
    {
        private readonly List<Reward> rewardUser = new List<Reward>();
        public void Add(Reward reward)
        {
            rewardUser.Add(reward);
        }
        public void Remove(Reward reward)
        {
            rewardUser.Remove(reward);
        }
        public void Update(Reward reward, string title, string description)
        {
            reward.Title = title;
            reward.Description = description;
        }
        public List<Reward> GetAll()
        {
            return rewardUser.ToList();
        }
    }
}
