using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Interfaces;
using PL;
using System.Linq;

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
        private void MainForm_Load(object sender, EventArgs e)
        {
            userGridView.DataSource = new MyBindingList<User>(userBL.GetAll().ToArray());
            rewardGridView.DataSource = new MyBindingList<Reward>(rewardBL.GetAll().ToArray());
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Федотов Михаил.");
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            userGridView.DataSource = new MyBindingList<User>(userBL.GetAll().ToArray());
            rewardGridView.DataSource = new MyBindingList<Reward>(rewardBL.GetAll().ToArray());
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            AddUserForm f = new AddUserForm(userBL, rewardBL);
            f.ShowDialog();
        }

        private void CreateReward_Click(object sender, EventArgs e)
        {
            AddRewardForm f = new AddRewardForm(rewardBL);
            f.ShowDialog();
        }
        private void RewardGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(rewardGridView[0, e.RowIndex].Value);
            var reward = rewardBL.GetAll().First(x => x.Id == id);
            if (radioButton1.Checked == true)
            {
                EditRewardForm f = new EditRewardForm(rewardBL, reward);
                f.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Удаление данных", $"Вы действительно хотите удалить награду c id {id}?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rewardBL.Remove(reward);
                }
                UpdateData();
            }
        }

        private void UserGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(userGridView[0, e.RowIndex].Value);
            var user = userBL.GetAll().First(x => x.Id == id);
            if (radioButton1.Checked == true)
            {
                EditUserForm f = new EditUserForm(userBL, rewardBL, user);
                f.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Удаление данных", $"Вы действительно хотите удалить пользователя c id {id}?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    userBL.Remove(user);
                }
                UpdateData();
            }

        }
    }
}