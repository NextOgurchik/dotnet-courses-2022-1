using BLL;
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
    public partial class EditRewardForm : Form
    {
        public readonly IRewardBL rewardBL;
        readonly Reward reward;
        public EditRewardForm(IRewardBL rewardBL, Reward reward)
        {
            InitializeComponent();
            this.reward = reward;
            this.rewardBL = rewardBL;
        }

        private void EditRewardForm_Load(object sender, EventArgs e)
        {
            firstName.Text = reward.Title;
            lastName.Text = reward.Description;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                rewardBL.Update(new Reward(reward.Id, firstName.Text, lastName.Text));
                Close();
            }
            catch { MessageBox.Show("Ошибка записи данных."); }
        }
    }
}
