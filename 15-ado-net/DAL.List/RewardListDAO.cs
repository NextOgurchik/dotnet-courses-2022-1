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
        private readonly List<Reward> listReward = new List<Reward>();
        public void Add(Reward reward)
        {
            listReward.Add(reward);
        }
        public void Remove(Reward reward)
        {
            var userList = _userDAO.GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                _userDAO.RemoveReward(userList[i], reward);
            }
            listReward.Remove(reward);
        }
        public void Update(Reward reward)
        {
            for (int i = 0; i < listReward.Count; i++)
            {
                if (listReward[i].Id == reward.Id)
                {
                    listReward[i].Title = reward.Title;
                    listReward[i].Description = reward.Description;
                }
            }
        }
        public List<Reward> GetAll()
        {
            return listReward.ToList();
        }
    }
}
