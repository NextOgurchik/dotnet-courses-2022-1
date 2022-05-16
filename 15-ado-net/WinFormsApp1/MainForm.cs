using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Interfaces;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public readonly IUserBL userBL;
        public readonly IRewardBL rewardBL;
        public MainForm(IUserBL userBL, IRewardBL rewardBL)
        {
            this.userBL = userBL;
            this.rewardBL = rewardBL;
            InitializeComponent();
        }
        private enum mode
        {
            Standart,
            AddUser,
            EditUser,
            AddReward,
            EditReward
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            userGridView.DataSource = new MyBindingList<User>(userBL.GetAll().ToArray());
            rewardGridView.DataSource = new MyBindingList<Reward>(rewardBL.GetAll().ToArray());
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm f = new AddEditForm(Convert.ToInt32(mode.AddUser), userBL, rewardBL);
            f.ShowDialog();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm f = new AddEditForm(Convert.ToInt32(mode.EditUser), userBL, rewardBL);
            f.ShowDialog();
        }

        private void addRewardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditForm f = new AddEditForm(Convert.ToInt32(mode.AddReward), userBL, rewardBL);
            f.ShowDialog();
        }

        private void editRewardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditForm f = new AddEditForm(Convert.ToInt32(mode.EditReward), userBL, rewardBL);
            f.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Федотов Михаил.");
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userGridView.DataSource = new MyBindingList<User>(userBL.GetAll().ToArray());
            rewardGridView.DataSource = new MyBindingList<Reward>(rewardBL.GetAll().ToArray());
        }
    }
}