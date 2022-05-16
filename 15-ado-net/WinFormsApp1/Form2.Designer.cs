namespace WinFormsApp1
{
    partial class AddEditForm
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
            this.save = new System.Windows.Forms.Button();
            this.age = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.moveRight = new System.Windows.Forms.Button();
            this.moveLeft = new System.Windows.Forms.Button();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.remove = new System.Windows.Forms.Button();
            this.listRewards = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(528, 150);
            this.save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(117, 43);
            this.save.TabIndex = 25;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(528, 88);
            this.age.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.age.Multiline = true;
            this.age.Name = "age";
            this.age.ReadOnly = true;
            this.age.Size = new System.Drawing.Size(116, 42);
            this.age.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(528, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "Возраст";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // moveRight
            // 
            this.moveRight.Location = new System.Drawing.Point(473, 150);
            this.moveRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(47, 43);
            this.moveRight.TabIndex = 22;
            this.moveRight.Text = ">";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.moveRight_Click);
            // 
            // moveLeft
            // 
            this.moveLeft.Location = new System.Drawing.Point(418, 150);
            this.moveLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(47, 43);
            this.moveLeft.TabIndex = 21;
            this.moveLeft.Text = "<";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.Click += new System.EventHandler(this.moveLeft_Click);
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(281, 88);
            this.lastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lastName.Multiline = true;
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(116, 42);
            this.lastName.TabIndex = 19;
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(158, 88);
            this.firstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstName.Multiline = true;
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(116, 42);
            this.firstName.TabIndex = 18;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(34, 88);
            this.id.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.id.Multiline = true;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(116, 42);
            this.id.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(405, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Дата рождения";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(281, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Фамилия";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(158, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Имя";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // birthdate
            // 
            this.birthdate.Location = new System.Drawing.Point(405, 97);
            this.birthdate.Name = "birthdate";
            this.birthdate.Size = new System.Drawing.Size(115, 23);
            this.birthdate.TabIndex = 27;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(293, 150);
            this.remove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(117, 43);
            this.remove.TabIndex = 28;
            this.remove.Text = "Удалить";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // listRewards
            // 
            this.listRewards.FormattingEnabled = true;
            this.listRewards.Location = new System.Drawing.Point(34, 150);
            this.listRewards.Name = "listRewards";
            this.listRewards.Size = new System.Drawing.Size(240, 76);
            this.listRewards.TabIndex = 29;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 248);
            this.Controls.Add(this.listRewards);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.save);
            this.Controls.Add(this.age);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.moveRight);
            this.Controls.Add(this.moveLeft);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "AddEditForm";
            this.Text = "Создание и редактирование";
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button moveRight;
        private System.Windows.Forms.Button moveLeft;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.CheckedListBox listRewards;
    }
}