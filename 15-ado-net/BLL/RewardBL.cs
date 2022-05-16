using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RewardBL: IRewardBL
    {
        private IRewardDAO _rewardDAO;
        public RewardBL(IRewardDAO rewardDAO)
        {
            _rewardDAO = rewardDAO;
        }
        public List<Reward> GetAll()
        {
            return _rewardDAO.GetAll();
        }
        public void Add(Reward reward)
        {
            _rewardDAO.Add(reward);
        }
        public void Remove(Reward reward)
        {
            _rewardDAO.Remove(reward);
        }
        public void Update(int rewardId, Reward reward)
        {
            _rewardDAO.Update(rewardId, reward);
        }
    }
}
