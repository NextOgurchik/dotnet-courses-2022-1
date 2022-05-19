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
    public partial class AddRewardForm : Form
    {
        public readonly IRewardBL rewardBL;
        public AddRewardForm(IRewardBL rewardBL)
        {
            this.rewardBL = rewardBL;
            InitializeComponent();
        }

        private void AddRewardForm_Load(object sender, EventArgs e)
        {

        }
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                rewardBL.Add(new Reward(firstName.Text, lastName.Text));
                Close();
            }
            catch { MessageBox.Show("Ошибка записи данных."); }
        }
    }
}
