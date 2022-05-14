using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        readonly int m;
        int number = 0;
        public Form2(int mode)
        {
            InitializeComponent();
            m = mode;
        }

        private void Form2_Load(object sender, EventArgs e)
        {         
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
                for (int i = 0; i < List.ListRewards.Count; i++)
                {
                    checkedListBox1.Items.Add(List.ListRewards[i].Title);
                }
            }

            else if (m == 2)
            {
                Text = "Редактирование пользователей";
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
                button1.Enabled = false;
                if (List.ListUsers.Count == 1)
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
                textBox1.Text = Convert.ToString(List.ListUsers[0].Id);
                textBox2.Text = List.ListUsers[0].FirstName;
                textBox3.Text = List.ListUsers[0].LastName;
                dateTimePicker1.Text = Convert.ToString(List.ListUsers[0].Birthdate);
                textBox5.Text = Convert.ToString(List.ListUsers[0].Age);
                for (int i = 0; i < List.ListRewards.Count; i++)
                {
                    checkedListBox1.Items.Add(List.ListRewards[i].Title);
                }
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (List.ListUsers[0].ListReward.Contains(List.ListRewards[i]))
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
                if (List.ListRewards.Count == 1)
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
                textBox1.Text = Convert.ToString(List.ListRewards[0].Id);
                textBox2.Text = List.ListRewards[0].Title;
                textBox3.Text = List.ListRewards[0].Description;
                label2.Text = "Наименование";
                label3.Text = "Описание";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                List.ListUsers.Add(new User(textBox2.Text, textBox3.Text, dateTimePicker1.Value));
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]))
                    {
                        List.ListUsers[List.ListUsers.Count - 1].ListReward.Add(List.ListRewards[i]);
                    }
                }
                Close();
            }
            else if (m == 2)
            {
                List.ListUsers[number].FirstName = textBox2.Text;
                List.ListUsers[number].LastName = textBox3.Text;
                List.ListUsers[number].Birthdate = dateTimePicker1.Value;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i]))
                    {
                        if (!List.ListUsers[number].ListReward.Contains(List.ListRewards[i]))
                        {
                            List.ListUsers[number].ListReward.Add(List.ListRewards[i]);
                        }
                    }
                    else
                    {
                        if (List.ListUsers[number].ListReward.Contains(List.ListRewards[i]))
                        {
                            List.ListUsers[number].ListReward.Remove(List.ListRewards[i]);
                        }
                    }
                }
            }
            else if (m == 3)
            {
                List.ListRewards.Add(new Reward(textBox2.Text, textBox3.Text));
                Close();
            }
            else if (m == 4)
            {
                List.ListRewards[number].Title = textBox2.Text;
                List.ListRewards[number].Description = textBox3.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number++;
            if ((m <= 2 && number >= List.ListUsers.Count-1) || (m >= 3 && number >= List.ListRewards.Count-1))
            {
                button2.Enabled = false;
            }
            if (m == 2)
            {
                textBox1.Text = Convert.ToString(List.ListUsers[number].Id);
                textBox2.Text = List.ListUsers[number].FirstName;
                textBox3.Text = List.ListUsers[number].LastName;
                dateTimePicker1.Value = List.ListUsers[number].Birthdate;
                textBox5.Text = Convert.ToString(List.ListUsers[number].Age);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (List.ListUsers[number].ListReward.Contains(List.ListRewards[i]))
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
                textBox1.Text = Convert.ToString(List.ListRewards[number].Id);
                textBox2.Text = List.ListRewards[number].Title;
                textBox3.Text = List.ListRewards[number].Description;
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
                textBox1.Text = Convert.ToString(List.ListUsers[number].Id);
                textBox2.Text = List.ListUsers[number].FirstName;
                textBox3.Text = List.ListUsers[number].LastName;
                dateTimePicker1.Value = List.ListUsers[number].Birthdate;
                textBox5.Text = Convert.ToString(List.ListUsers[number].Age);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (List.ListUsers[number].ListReward.Contains(List.ListRewards[i]))
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
                textBox1.Text = Convert.ToString(List.ListRewards[number].Id);
                textBox2.Text = List.ListRewards[number].Title;
                textBox3.Text = List.ListRewards[number].Description;
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
                    List.ListUsers.Remove(List.ListUsers[number]);
                    Close();
                }
            }
            else if (m == 4)
            {
                DialogResult dialogResult = MessageBox.Show("Удаление данных", "Вы действительно хотите удалить эту награду?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < List.ListUsers.Count; i++)
                    {
                        if (List.ListUsers[i].ListReward.Contains(List.ListRewards[number]))
                        {
                            List.ListUsers[i].ListReward.Remove(List.ListRewards[number]);
                        }
                    }
                    List.ListRewards.Remove(List.ListRewards[number]);
                    Close();
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
