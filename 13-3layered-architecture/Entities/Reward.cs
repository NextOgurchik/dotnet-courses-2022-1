using System;

namespace Entities
{
    public class Reward
    {
        public int Id { get; }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("The string is too long.");
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
                if (value.Length > 250)
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
    }
}
