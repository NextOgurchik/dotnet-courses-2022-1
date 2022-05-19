namespace UsersRewardsWeb.Models
{
    using global::Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace Entities
    {
        public class RewardViewModel
        {
            [Required]
            public int Id { get; set; }
            [Required(ErrorMessage = "Название награды обязательно")]
            public string Title { get; set; }
            public string Description { get; set; }
            public RewardViewModel(Reward reward)
            {
                Id = reward.Id;
                Title = reward.Title;
                Description = reward.Description;
            }
            public RewardViewModel()
            {

            }
        }
    }

}
