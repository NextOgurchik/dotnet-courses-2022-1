using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PL
{
    public partial class EditUserForm : Form
    {
        public readonly IUserBL userBL;
        public readonly IRewardBL rewardBL;
        List<Reward> rewards;
        User user;
        public EditUserForm(IUserBL userBL, IRewardBL rewardBL, User user)
        {
            InitializeComponent();
            this.userBL = userBL;
            this.rewardBL = rewardBL;
            this.user = user;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            rewards = rewardBL.GetAll();
            firstName.Text = user.FirstName;
            lastName.Text = user.LastName;
            birthdate.Text = Convert.ToString(user.Birthdate);
            for (int i = 0; i < rewards.Count; i++)
            {
                listRewards.Items.Add(rewards[i].Title);
            }

            for (int i = 0; i < listRewards.Items.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < user.ListReward.Count; j++)
                {
                    if (user.ListReward[j].Id == rewards[i].Id)
                    {
                        isContains = true;
                    }
                }

                if (isContains)
                {
                    listRewards.SetItemChecked(i, true);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                userBL.Update(new User(user.Id, firstName.Text, lastName.Text, birthdate.Value));
                for (int i = 0; i < listRewards.Items.Count; i++)
                {
                    if (listRewards.CheckedItems.Contains(listRewards.Items[i]))
                    {
                        userBL.AddReward(user, rewards[i]);
                    }
                    else
                    {
                        userBL.RemoveReward(user, rewards[i]);
                    }
                }
                Close();
            }
            catch { MessageBox.Show("Ошибка записи данных."); }
        }
    }
}
