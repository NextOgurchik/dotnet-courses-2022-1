using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var listUsers = new List<User>();
            var listRewards = new List<Reward>();
            listUsers.Add(new User("Иван", "Иванов", new DateTime(1998, 5, 14)));
            listUsers.Add(new User("Иван", "Иванов", new DateTime(1996, 12, 13)));
            listUsers.Add(new User("Иван", "Иванов", new DateTime(1992, 1, 3)));
            listUsers.Add(new User("Иван", "Иванов", new DateTime(1991, 4, 4)));
            listUsers.Add(new User("Иван", "Иванов", new DateTime(1992, 1, 22)));
            listRewards.Add(new Reward("Нобелевская премия", "Одна из наиболее престижных международных премий, ежегодно присуждаемая за выдающиеся научные исследования, революционные изобретения или крупный вклад в культуру или развитие общества."));
            listRewards.Add(new Reward("Премия Дарвина", "Виртуальная антипремия, ежегодно присуждаемая лицам, которые наиболее глупым способом умерли или потеряли способность иметь детей и в результате лишили себя возможности внести вклад в генофонд человечества, тем самым потенциально улучшив его."));
            listRewards.Add(new Reward("Крутая медаль"));
            listUsers[0].AddReward(listRewards[0]);
            new List(listUsers, listRewards);      
            dataGridView1.DataSource = new MyBindingList<User>(List.ListUsers.ToArray());
            dataGridView2.DataSource = new MyBindingList<Reward>(List.ListRewards.ToArray());
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(1);
            f.ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(2);
            f.ShowDialog();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(3);
            f.ShowDialog();
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(4);
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
            dataGridView1.DataSource = new MyBindingList<User>(List.ListUsers.ToArray());
            dataGridView2.DataSource = new MyBindingList<Reward>(List.ListRewards.ToArray());
        }
    }
}