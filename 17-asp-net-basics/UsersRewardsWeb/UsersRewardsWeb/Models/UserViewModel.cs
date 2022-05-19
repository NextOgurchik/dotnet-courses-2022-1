using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UsersRewardsWeb.Models.Entities;

namespace UsersRewardsWeb.Models
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия пользователя обязательна")]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public List<Reward> ListReward { get; set; }
        public List<Reward> Rewards { get; set; }
        public UserViewModel(User user, List<Reward> rewards)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;
            ListReward = user.ListReward;
            Rewards = rewards;
        }
        public UserViewModel()
        {

        }
    }
}
