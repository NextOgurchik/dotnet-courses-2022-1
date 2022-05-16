using System.Collections.Generic;
using Entities;
using Interfaces;
using System.Linq;

namespace DAL
{
    public class RewardListDAO : IRewardDAO
    {
        private IUserDAO _userDAO;
        public RewardListDAO(IUserDAO userDAO) 
        {
            _userDAO = userDAO;
        }
        private readonly List<Reward> rewardUser = new List<Reward>();
        public void Add(Reward reward)
        {
            rewardUser.Add(reward);
        }
        public void Remove(Reward reward)
        {
            var userList = _userDAO.GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                _userDAO.RemoveReward(userList[i], reward);
            }
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
