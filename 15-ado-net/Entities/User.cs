﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length > 50 || value.Length < 1)
                {
                    throw new Exception("The string is too long or contains less than 1 character.");
                }
                firstName = value;
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > 50 || value.Length < 1)
                {
                    throw new Exception("The string is too long or contains less than 1 character.");
                }
                lastName = value;
            }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                if (value < DateTime.Now && DateTime.Now.Year - value.Year < 150)
                {
                    birthdate = value;
                }
                else
                {
                    throw new Exception("User too old or hasn't been born yet.");
                }
            }
        }
        public int Age
        {
            get
            {
                int a = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now.Month < Birthdate.Month)
                {
                    a--;
                }
                else if (DateTime.Now.Month == Birthdate.Month)
                {
                    if (DateTime.Now.Day < Birthdate.Day)
                    {
                        a--;
                    }
                }
                return a;
            }
        }
        public List<Reward> ListReward { get; set; }
        public string Rewards
        {
            get
            {
                return string.Join(" | ", ListReward.Select(l => l.Title));
            }
        }

        public User(string firstName, string lastName, DateTime birthdate)
        {
            Id = Math.Abs((int)DateTime.Now.Ticks);
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            ListReward = new List<Reward>();
        }

        public User(int id, string firstName, string lastName, DateTime birthdate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            ListReward = new List<Reward>();
        }
        public void AddReward(Reward reward)
        {
            ListReward.Add(reward);
        }
    }
}
