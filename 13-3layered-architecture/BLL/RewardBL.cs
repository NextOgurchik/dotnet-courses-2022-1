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
        public void Update(Reward reward, string title, string description)
        {
            _rewardDAO.Update(reward, title, description);
        }
        public void SetDescription(Reward reward, string description)
        {
            reward.Description = description;
        }
    }
}
