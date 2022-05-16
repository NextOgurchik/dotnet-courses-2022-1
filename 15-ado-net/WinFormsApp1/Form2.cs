using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Entities;
using Interfaces;

namespace WinFormsApp1
{
    public partial class AddEditForm : Form
    {
        readonly int m;
        int number = 0;
        List<User> users;
        List<Reward> rewards;

        public readonly IUserBL userBL;
        public readonly IRewardBL rewardBL;
        public AddEditForm(int mode, IUserBL userBL, IRewardBL rewardBL)
        {
            InitializeComponent();
            this.userBL = userBL;
            this.rewardBL = rewardBL;
            m = mode;
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            users = userBL.GetAll();
            rewards = rewardBL.GetAll();

            if (m == 1)
            {
                Text = "Создание пользователей";
                moveLeft.Visible = false;
                moveRight.Visible = false;
                remove.Visible = false;
                id.Visible = false;
                birthdate.Visible = true;
                age.Visible = true;
                label1.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                listRewards.Visible = true;
                id.Clear();
                firstName.Clear();
                lastName.Clear();
                age.Clear();
                label2.Text = "Имя";
                label3.Text = "Фамилия";
                label4.Text = "Дата рождения";
                label5.Text = "Возраст";
                for (int i = 0; i < rewards.Count; i++)
                {
                    listRewards.Items.Add(rewards[i].Title);
                }
            }

            else if (m == 2)
            {
                Text = "Редактирование пользователей";
                moveLeft.Visible = true;
                moveRight.Visible = true;
                remove.Visible = true;
                moveLeft.Enabled = false;
                if (users.Count == 1)
                {
                    moveRight.Enabled = false;
                    remove.Enabled = false;
                }
                id.Visible = true;
                birthdate.Visible = true;
                age.Visible = true;
                label1.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                listRewards.Visible = true;
                id.Text = Convert.ToString(users[0].Id);
                firstName.Text = users[0].FirstName;
                lastName.Text = users[0].LastName;
                birthdate.Text = Convert.ToString(users[0].Birthdate);
                age.Text = Convert.ToString(users[0].Age);
                for (int i = 0; i < rewards.Count; i++)
                {
                    listRewards.Items.Add(rewards[i].Title);
                }
                
                for (int i = 0; i < listRewards.Items.Count; i++)
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
                        listRewards.SetItemChecked(i, true);
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
                moveLeft.Visible = false;
                moveRight.Visible = false;
                remove.Visible = false;
                id.Visible = false;
                birthdate.Visible = false;
                age.Visible = false;
                label1.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                listRewards.Visible = false;
                id.Clear();
                firstName.Clear();
                lastName.Clear();
                label2.Text = "Наименование";
                label3.Text = "Описание";
            }

            else if (m == 4)
            {
                Text = "Редактирование наград";
                moveLeft.Visible = true;
                moveRight.Visible = true;
                remove.Visible = true;
                moveLeft.Enabled = false;
                if (rewards.Count == 1)
                {
                    moveRight.Enabled = false;
                    remove.Enabled = false;
                }
                id.Visible = true;
                birthdate.Visible = false;
                age.Visible = false;
                label1.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                listRewards.Visible = false;
                id.Text = Convert.ToString(rewards[0].Id);
                firstName.Text = rewards[0].Title;
                lastName.Text = rewards[0].Description;
                label2.Text = "Наименование";
                label3.Text = "Описание";
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                userBL.Add(new User(firstName.Text, lastName.Text, birthdate.Value));
                for (int i = 0; i < listRewards.Items.Count; i++)
                {
                    if (listRewards.CheckedItems.Contains(listRewards.Items[i]))
                    {
                        userBL.AddReward(users[users.Count - 1], rewards[i]);
                    }
                }
                Close();
            }
            else if (m == 2)
            {
                userBL.Update(users[number].Id, new User(firstName.Text, lastName.Text, birthdate.Value));
                for (int i = 0; i < listRewards.Items.Count; i++)
                {
                    if (listRewards.CheckedItems.Contains(listRewards.Items[i]))
                    {
                        userBL.AddReward(users[number], rewards[i]);
                    }
                    else//если нет галочки
                    {
                        userBL.RemoveReward(users[number], rewards[i]);
                    }
                }
            }
            else if (m == 3)
            {
                rewardBL.Add(new Reward(firstName.Text, lastName.Text));
                Close();
            }
            else if (m == 4)
            {
                rewardBL.Update(rewards[number].Id, new Reward(firstName.Text, lastName.Text));
            }
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            number++;
            if ((m <= 2 && number >= users.Count-1) || (m >= 3 && number >= rewards.Count-1))
            {
                moveRight.Enabled = false;
            }
            if (m == 2)
            {
                id.Text = Convert.ToString(users[number].Id);
                firstName.Text = users[number].FirstName;
                lastName.Text = users[number].LastName;
                birthdate.Value = users[number].Birthdate;
                age.Text = Convert.ToString(users[number].Age);

                for (int i = 0; i < listRewards.Items.Count; i++)
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
                        listRewards.SetItemChecked(i, true);
                    }

                    else
                    {
                        listRewards.SetItemChecked(i, false);
                    }
                }
            }
            if (m == 4)
            {
                id.Text = Convert.ToString(rewards[number].Id);
                firstName.Text = rewards[number].Title;
                lastName.Text = rewards[number].Description;
            }
            moveLeft.Enabled = true;
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            number--;
            if (number < 1)
            {
                moveLeft.Enabled = false;
            }
            if (m == 2)
            {
                id.Text = Convert.ToString(users[number].Id);
                firstName.Text = users[number].FirstName;
                lastName.Text = users[number].LastName;
                birthdate.Value = users[number].Birthdate;
                age.Text = Convert.ToString(users[number].Age);
                for (int i = 0; i < listRewards.Items.Count; i++)
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
                        listRewards.SetItemChecked(i, true);
                    }
                    else
                    {
                        listRewards.SetItemChecked(i, false);
                    }
                }
            }
            if (m == 4)
            {
                id.Text = Convert.ToString(rewards[number].Id);
                firstName.Text = rewards[number].Title;
                lastName.Text = rewards[number].Description;
            }
            moveRight.Enabled = true;
        }

        private void remove_Click(object sender, EventArgs e)
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
