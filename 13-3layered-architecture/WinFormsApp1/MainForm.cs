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
            userBL.Add(new User("Иван", "Иванов", new DateTime(1998, 5, 14)));
            userBL.Add(new User("Сергей", "Степушкин", new DateTime(1996, 12, 13)));
            userBL.Add(new User("Анатолий", "Тарасов", new DateTime(1992, 1, 3)));
            userBL.Add(new User("Степан", "Часовитин", new DateTime(1991, 4, 4)));
            userBL.Add(new User("Андрей", "Прошев", new DateTime(1992, 1, 22)));
            rewardBL.Add(new Reward("Нобелевская премия", "Одна из наиболее престижных международных премий, ежегодно присуждаемая за выдающиеся научные исследования, революционные изобретения или крупный вклад в культуру или развитие общества."));
            rewardBL.Add(new Reward("Премия Дарвина", "Виртуальная антипремия, ежегодно присуждаемая лицам, которые наиболее глупым способом умерли или потеряли способность иметь детей и в результате лишили себя возможности внести вклад в генофонд человечества, тем самым потенциально улучшив его."));
            rewardBL.Add(new Reward("Крутая медаль"));
            
            var users = userBL.GetAll();
            var rewards = rewardBL.GetAll();

            userBL.AddReward(users[0], rewards[0]);
            
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