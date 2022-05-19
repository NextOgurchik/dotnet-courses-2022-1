using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace PL
{
    public partial class AddUserForm : Form
    {
        public readonly IUserBL userBL;
        public readonly IRewardBL rewardBL;
        List<Reward> rewards;
        public AddUserForm(IUserBL userBL, IRewardBL rewardBL)
        {
            this.userBL = userBL;
            this.rewardBL = rewardBL;
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            rewards = rewardBL.GetAll();
            for (int i = 0; i < rewards.Count; i++)
            {
                listRewards.Items.Add(rewards[i].Title);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                userBL.Add(new User(firstName.Text, lastName.Text, birthdate.Value));
                for (int i = 0; i < listRewards.Items.Count; i++)
                {
                    if (listRewards.CheckedItems.Contains(listRewards.Items[i]))
                    {
                        userBL.AddReward(userBL.GetAll().OrderByDescending(u => u.Id).First(), rewards[i]);
                    }
                }

                Close();
            }
            catch { MessageBox.Show("Ошибка записи данных."); }
        }
    }
}
