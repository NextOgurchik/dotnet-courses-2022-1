using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Entities;
using Interfaces;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        readonly int m;
        int number = 0;
        List<User> users;
        List<Reward> rewards;

        public readonly IUserBL userBL;
        public readonly IRewardBL rewardBL;
        public Form2(int mode, IUserBL userBL, IRewardBL rewardBL)
        {
            InitializeComponent();
            this.userBL = userBL;
            this.rewardBL = rewardBL;
            m = mode;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            users = userBL.GetAll();
            rewards = rewardBL.GetAll();

            if (m == 1)
            {
                Text = "Создание пользователей";
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                dateTimePicker1.Visible = true;
                textBox5.Visible = true;
                label1.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                checkedListBox1.Visible = true;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                label2.Text = "Имя";
                label3.Text = "Фамилия";
                label4.Text = "Дата рождения";
                label5.Text = "Возраст";
                for (int i = 0; i < rewards.Count; i++)
                {
                    checkedListBox1.Items.Add(rewards[i].Title);
                }
            }

            else if (m == 2)
            {
                Text = "Редактирование пользователей";
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
                button1.Enabled = false;
                if (users.Count == 1)
                {
                    button2.Enabled = false;
                    button4.Enabled = false;
                }
                textBox1.Visible = true;
                dateTimePicker1.Visible = true;
                textBox5.Visible = true;
                label1.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                checkedListBox1.Visible = true;
                textBox1.Text = Convert.ToString(users[0].Id);
                textBox2.Text = users[0].FirstName;
                textBox3.Text = users[0].LastName;
                dateTimePicker1.Text = Convert.ToString(users[0].Birthdate);
                textBox5.Text = Convert.ToString(users[0].Age);
                for (int i = 0; i < rewards.Count; i++)
                {
                    checkedListBox1.Items.Add(rewards[i].Title);
                }

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    bool isContains = false;
                    for (int j = 0; j < users[0].ListReward.Count; j++)
                    {
                        if (users[number].ListReward[j].Id == rewards[i].Id)
                        {
                            isContains = true;
                        }
                    }

                    if (isContains)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }

                label2.Text = "Имя";
                label3.Text = "Фамилия";
                label4.Text = "Дата рождения";
                label5.Text = "Возраст";
            }

            else if (m == 3)
            {
                Text = "Создание наград";
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                textBox5.Visible = false;
                label1.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                checkedListBox1.Visible = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                label2.Text = "Наименование";
                label3.Text = "Описание";
            }

            else if (m == 4)
            {
                Text = "Редактирование наград";
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
                button1.Enabled = false;
                if (rewards.Count == 1)
                {
                    button2.Enabled = false;
                    button4.Enabled = false;
                }
                textBox1.Visible = true;
                dateTimePicker1.Visible = false;
                textBox5.Visible = false;
                label1.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                checkedListBox1.Visible = false;
                textBox1.Text = Convert.ToString(rewards[0].Id);
                textBox2.Text = rewards[0].Title;
                textBox3.Text = rewards[0].Description;
                label2.Text = "Наименование";
                label3.Text = "Описание";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                userBL.Add(new User(textBox2.Text, textBox3.Text, dateTimePicker1.Value));
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]))
                    {
                        userBL.AddReward(users[users.Count - 1], rewards[i]);
                    }
                }
                Close();
            }
            else if (m == 2)
            {
                userBL.Update(users[number], textBox2.Text, textBox3.Text, dateTimePicker1.Value);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]))
                    {
                        if (!users[number].ListReward.Contains(rewards[i]))
                        {
                            userBL.AddReward(users[number], rewards[i]);
                        }
                    }
                    else
                    {
                        if (users[number].ListReward.Contains(rewards[i]))
                        {
                            userBL.RemoveReward(users[number], rewards[i]);
                        }
                    }
                }
            }
            else if (m == 3)
            {
                rewardBL.Add(new Reward(textBox2.Text, textBox3.Text));
                Close();
            }
            else if (m == 4)
            {
                rewardBL.Update(rewards[number], textBox2.Text, textBox3.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number++;
            if ((m <= 2 && number >= users.Count - 1) || (m >= 3 && number >= rewards.Count - 1))
            {
                button2.Enabled = false;
            }
            if (m == 2)
            {
                textBox1.Text = Convert.ToString(users[number].Id);
                textBox2.Text = users[number].FirstName;
                textBox3.Text = users[number].LastName;
                dateTimePicker1.Value = users[number].Birthdate;
                textBox5.Text = Convert.ToString(users[number].Age);

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    bool isContains = false;
                    for (int j = 0; j < users[number].ListReward.Count; j++)
                    {
                        if (users[number].ListReward[j].Id == rewards[i].Id)
                        {
                            isContains = true;
                        }
                    }

                    if (isContains)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }

                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
            if (m == 4)
            {
                textBox1.Text = Convert.ToString(rewards[number].Id);
                textBox2.Text = rewards[number].Title;
                textBox3.Text = rewards[number].Description;
            }
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number--;
            if (number < 1)
            {
                button1.Enabled = false;
            }
            if (m == 2)
            {
                textBox1.Text = Convert.ToString(users[number].Id);
                textBox2.Text = users[number].FirstName;
                textBox3.Text = users[number].LastName;
                dateTimePicker1.Value = users[number].Birthdate;
                textBox5.Text = Convert.ToString(users[number].Age);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (users[number].ListReward.Contains(rewards[i]))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
            if (m == 4)
            {
                textBox1.Text = Convert.ToString(rewards[number].Id);
                textBox2.Text = rewards[number].Title;
                textBox3.Text = rewards[number].Description;
            }
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m == 2)
            {
                DialogResult dialogResult = MessageBox.Show("Удаление данных", "Вы действительно хотите удалить этого пользователя?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    userBL.Remove(users[number]);
                    Close();
                }
            }
            else if (m == 4)
            {
                DialogResult dialogResult = MessageBox.Show("Удаление данных", "Вы действительно хотите удалить эту награду?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rewardBL.Remove(rewards[number]);
                    Close();
                }
            }
        }
    }
}
