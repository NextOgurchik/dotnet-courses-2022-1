using DAL.Db;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersRewardsWeb.Models;

namespace UsersRewardsWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBL userBL;
        private readonly IRewardBL rewardBL;
        public UserController(IUserBL userBL, IRewardBL rewardBL)
        {
            this.userBL = userBL;
            this.rewardBL = rewardBL;
        }
        public IActionResult Index()
        {
            var users = userBL.GetAll();
            return View(users);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var user = userBL.Get(id);
            userBL.Remove(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = userBL.Get(id);
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ListReward = userBL.GetAll().First(x => x.Id == user.Id).ListReward,
                Rewards = rewardBL.GetAll()
            };

            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Update(UserViewModel user, List<string> userAwarded)
        {
            if (!ModelState.IsValid)
            {
                var oldUser = userBL.Get(user.Id);
                var userViewModel = new UserViewModel()
                {
                    Id = oldUser.Id,
                    FirstName = oldUser.FirstName,
                    LastName = oldUser.LastName,
                    Birthdate = oldUser.Birthdate,
                    ListReward = userBL.GetAll().First(x => x.Id == user.Id).ListReward,
                    Rewards = rewardBL.GetAll()
                };
                return View(userViewModel);
            }
            var rewards = rewardBL.GetAll();

            var userToUpdate = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ListReward = userBL.GetAll().First(x => x.Id == user.Id).ListReward
            };
            userBL.Update(userToUpdate);
            for (int i = 0; i < rewards.Count; i++)
            {
                bool isAwarded = false;
                for (int j = 0; j < userAwarded.Count; j++)
                {
                    if (rewards[i].Id == Convert.ToInt32(userAwarded[j]))
                    {
                        isAwarded = true;
                    }
                }
                if (isAwarded)
                {
                    userBL.AddReward(userToUpdate, rewards[i]);
                }
                else
                {
                    userBL.RemoveReward(userToUpdate, rewards[i]);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userViewModel = new UserViewModel(new User(), rewardBL.GetAll());

            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Add(UserViewModel user, List<string> userAwarded)
        {
            if (!ModelState.IsValid)
            {
                var userViewModel = new UserViewModel()
                {
                    Rewards = rewardBL.GetAll()
                };
                return View(userViewModel);
            }
            var rewards = rewardBL.GetAll();

            var userToUpdate = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ListReward = new List<Reward>()
            };
            var id = userBL.Add(userToUpdate);
            for (int i = 0; i < rewards.Count; i++)
            {
                for (int j = 0; j < userAwarded.Count; j++)
                {
                    if (rewards[i].Id == Convert.ToInt32(userAwarded[j]))
                    {
                        userBL.AddReward(userBL.Get(id), rewards[i]);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
