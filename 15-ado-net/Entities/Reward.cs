using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Reward
    {
        public int Id { get; set; }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length > 50 || value.Length < 1)
                {
                    throw new Exception("The string is too long or contains less than 1 character.");
                }
                title = value;
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value != null && value.Length > 250)
                {
                    throw new Exception("The string is too long.");
                }
                description = value;
            }
        }
        public Reward(string title)
        {
            Id = Math.Abs((int)DateTime.Now.Ticks);
            Title = title;
            Description = "";
        }
        public Reward(string title, string description) : this(title)
        {
            Description = description;
        }
        public Reward(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
        public Reward()
        {

        }
    }
}
