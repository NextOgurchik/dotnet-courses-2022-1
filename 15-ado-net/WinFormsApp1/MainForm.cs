using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DAL;
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

        private void MainForm_Load(object sender, EventArgs e)
        {                   
            dataGridView1.DataSource = new MyBindingList<User>(userBL.GetAll().ToArray());
            dataGridView2.DataSource = new MyBindingList<Reward>(rewardBL.GetAll().ToArray());
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(1, userBL, rewardBL);
            f.ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(2, userBL, rewardBL);
            f.ShowDialog();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(3, userBL, rewardBL);
            f.ShowDialog();
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(4, userBL, rewardBL);
            f.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Федотов Михаил.");
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new MyBindingList<User>(userBL.GetAll().ToArray());
            dataGridView2.DataSource = new MyBindingList<Reward>(rewardBL.GetAll().ToArray());
        }
    }
}