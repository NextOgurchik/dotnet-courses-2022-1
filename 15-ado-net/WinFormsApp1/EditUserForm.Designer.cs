namespace PL
{
    partial class EditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listRewards = new System.Windows.Forms.CheckedListBox();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.save = new System.Windows.Forms.Button();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listRewards
            // 
            this.listRewards.FormattingEnabled = true;
            this.listRewards.Location = new System.Drawing.Point(13, 104);
            this.listRewards.Name = "listRewards";
            this.listRewards.Size = new System.Drawing.Size(240, 76);
            this.listRewards.TabIndex = 52;
            // 
            // birthdate
            // 
            this.birthdate.Location = new System.Drawing.Point(324, 53);
            this.birthdate.Name = "birthdate";
            this.birthdate.Size = new System.Drawing.Size(115, 23);
            this.birthdate.TabIndex = 51;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.save.Location = new System.Drawing.Point(260, 104);
            this.save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(242, 76);
            this.save.TabIndex = 50;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(197, 44);
            this.lastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lastName.Multiline = true;
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(116, 42);
            this.lastName.TabIndex = 49;
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(74, 44);
            this.firstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstName.Multiline = true;
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(116, 42);
            this.firstName.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(321, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 47;
            this.label4.Text = "Дата рождения";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(197, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 29);
            this.label3.TabIndex = 46;
            this.label3.Text = "Фамилия";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(74, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 29);
            this.label2.TabIndex = 45;
            this.label2.Text = "Имя";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 191);
            this.Controls.Add(this.listRewards);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.save);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "EditUserForm";
            this.Text = "Изменить пользователя";
            this.Load += new System.EventHandler(this.EditUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listRewards;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}