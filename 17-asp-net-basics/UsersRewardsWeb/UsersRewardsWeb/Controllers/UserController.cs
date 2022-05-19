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
        private readonly IUserDAO userDAO;
        private readonly IRewardDAO rewardDAO;
        public UserController(IUserDAO userDAO, IRewardDAO rewardDAO)
        {
            this.userDAO = userDAO;
            this.rewardDAO = rewardDAO;
        }
        public IActionResult Index()
        {
            var users = userDAO.GetAll();
            return View(users);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var user = userDAO.GetAll().First(x => x.Id == id);
            userDAO.Remove(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = userDAO.GetAll().First(x => x.Id == id);
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ListReward = user.ListReward,
                Rewards = rewardDAO.GetAll()
            };

            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Update(UserViewModel user, List<string> userAwarded)
        {
            if (!ModelState.IsValid)
            {
                var oldUser = userDAO.GetAll().First(x => x.Id == user.Id);
                var userViewModel = new UserViewModel()
                {
                    Id = oldUser.Id,
                    FirstName = oldUser.FirstName,
                    LastName = oldUser.LastName,
                    Birthdate = oldUser.Birthdate,
                    ListReward = oldUser.ListReward,
                    Rewards = rewardDAO.GetAll()
                };
                return View(userViewModel);
            }
            var rewards = rewardDAO.GetAll();

            var userToUpdate = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ListReward = userDAO.GetAll().OrderByDescending(u => u.Id).First().ListReward
            };
            userDAO.Update(userToUpdate);
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
                    userDAO.AddReward(userToUpdate, rewards[i]);
                }
                else
                {
                    userDAO.RemoveReward(userToUpdate, rewards[i]);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userViewModel = new UserViewModel(new User(), rewardDAO.GetAll());

            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Add(UserViewModel user, List<string> userAwarded)
        {
            if (!ModelState.IsValid)
            {
                var userViewModel = new UserViewModel()
                {
                    Rewards = rewardDAO.GetAll()
                };
                return View(userViewModel);
            }
            var rewards = rewardDAO.GetAll();

            var userToUpdate = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ListReward = new List<Reward>()
            };
            userDAO.Add(userToUpdate);
            for (int i = 0; i < rewards.Count; i++)
            {
                for (int j = 0; j < userAwarded.Count; j++)
                {
                    if (rewards[i].Id == Convert.ToInt32(userAwarded[j]))
                    {
                        userDAO.AddReward(userDAO.GetAll().OrderByDescending(u => u.Id).First(), rewards[i]);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
