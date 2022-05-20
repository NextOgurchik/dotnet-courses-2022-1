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
        private readonly IRewardBL rewardBL;
        public RewardController(IRewardBL rewardBL)
        {
            this.rewardBL = rewardBL;
        }
        public IActionResult Index()
        {
            var rewards = rewardBL.GetAll();

            return View(rewards);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var reward = rewardBL.Get(id);
            rewardBL.Remove(reward);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var reward = rewardBL.Get(id);
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
            rewardBL.Update(rewardToUpdate);
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

            rewardBL.Add(rewardToUpdate);
            return RedirectToAction("Index");
        }
    }
}
