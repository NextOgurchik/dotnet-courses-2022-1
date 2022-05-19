using Microsoft.AspNetCore.Mvc;
using DAL.Db;
using Entities;
using Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
using UsersRewardsWeb.Models.Entities;

namespace UsersRewardsWeb.Controllers
{
    public class RewardController : Controller
    {
        private readonly IRewardDAO rewardDAO;
        public RewardController(IRewardDAO rewardDAO)
        {
            this.rewardDAO = rewardDAO;
        }
        public IActionResult Index()
        {
            var rewards = rewardDAO.GetAll();

            return View(rewards);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var reward = rewardDAO.GetAll().First(x => x.Id == id);
            rewardDAO.Remove(reward);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var reward = rewardDAO.GetAll().First(x => x.Id == id);
            var rewardViewModel = new RewardViewModel(reward);
            return View(rewardViewModel);
        }
        [HttpPost]
        public IActionResult Update(RewardViewModel reward)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var rewardToUpdate = new Reward
            {
                Id = reward.Id,
                Title = reward.Title,
                Description = reward.Description
            };
            rewardDAO.Update(rewardToUpdate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            var rewardViewModel = new RewardViewModel();
            return View(rewardViewModel);
        }
        [HttpPost]
        public IActionResult Add(RewardViewModel reward)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            var rewardToUpdate = new Reward()
            {
                Title = reward.Title,
                Description = reward.Description
            };

            rewardDAO.Add(rewardToUpdate);
            return RedirectToAction("Index");
        }
    }
}
