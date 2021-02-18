namespace TestApp
{
    partial class EmployeeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Patronimic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Surname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_female = new System.Windows.Forms.RadioButton();
            this.radioButton_male = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker_StartDateWork = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FireDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox_Fired = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_EmpPosition = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_SubDivisionsList = new System.Windows.Forms.ComboBox();
            this.button_SaveEmpData = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_TabNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBox_BirthPlace = new System.Windows.Forms.RichTextBox();
            this.textBox_INN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_BirthDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(89, 38);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(192, 22);
            this.textBox_Name.TabIndex = 1;
            // 
            // textBox_Patronimic
            // 
            this.textBox_Patronimic.Location = new System.Drawing.Point(89, 66);
            this.textBox_Patronimic.Name = "textBox_Patronimic";
            this.textBox_Patronimic.Size = new System.Drawing.Size(192, 22);
            this.textBox_Patronimic.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Отчество";
            // 
            // textBox_Surname
            // 
            this.textBox_Surname.Location = new System.Drawing.Point(89, 10);
            this.textBox_Surname.Name = "textBox_Surname";
            this.textBox_Surname.Size = new System.Drawing.Size(192, 22);
            this.textBox_Surname.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Фамилия";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioButton_female);
            this.panel1.Controls.Add(this.radioButton_male);
            this.panel1.Location = new System.Drawing.Point(11, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 38);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пол";
            // 
            // radioButton_female
            // 
            this.radioButton_female.AutoSize = true;
            this.radioButton_female.Location = new System.Drawing.Point(167, 14);
            this.radioButton_female.Name = "radioButton_female";
            this.radioButton_female.Size = new System.Drawing.Size(88, 21);
            this.radioButton_female.TabIndex = 4;
            this.radioButton_female.TabStop = true;
            this.radioButton_female.Text = "Женский";
            this.radioButton_female.UseVisualStyleBackColor = true;
            // 
            // radioButton_male
            // 
            this.radioButton_male.AutoSize = true;
            this.radioButton_male.Location = new System.Drawing.Point(73, 14);
            this.radioButton_male.Name = "radioButton_male";
            this.radioButton_male.Size = new System.Drawing.Size(86, 21);
            this.radioButton_male.TabIndex = 3;
            this.radioButton_male.TabStop = true;
            this.radioButton_male.Text = "Мужской";
            this.radioButton_male.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Дата устройства на работу";
            // 
            // dateTimePicker_StartDateWork
            // 
            this.dateTimePicker_StartDateWork.Location = new System.Drawing.Point(8, 296);
            this.dateTimePicker_StartDateWork.Name = "dateTimePicker_StartDateWork";
            this.dateTimePicker_StartDateWork.Size = new System.Drawing.Size(269, 22);
            this.dateTimePicker_StartDateWork.TabIndex = 8;
            // 
            // dateTimePicker_FireDate
            // 
            this.dateTimePicker_FireDate.Location = new System.Drawing.Point(8, 350);
            this.dateTimePicker_FireDate.Name = "dateTimePicker_FireDate";
            this.dateTimePicker_FireDate.Size = new System.Drawing.Size(269, 22);
            this.dateTimePicker_FireDate.TabIndex = 10;
            // 
            // checkBox_Fired
            // 
            this.checkBox_Fired.AutoSize = true;
            this.checkBox_Fired.Location = new System.Drawing.Point(12, 323);
            this.checkBox_Fired.Name = "checkBox_Fired";
            this.checkBox_Fired.Size = new System.Drawing.Size(92, 21);
            this.checkBox_Fired.TabIndex = 9;
            this.checkBox_Fired.Text = "Уволить?";
            this.checkBox_Fired.UseVisualStyleBackColor = true;
            this.checkBox_Fired.CheckedChanged += new System.EventHandler(this.checkBox_Fired_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Дата увольнения";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 393);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(269, 146);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Причина увольнения";
            // 
            // textBox_EmpPosition
            // 
            this.textBox_EmpPosition.Location = new System.Drawing.Point(442, 95);
            this.textBox_EmpPosition.Name = "textBox_EmpPosition";
            this.textBox_EmpPosition.Size = new System.Drawing.Size(610, 22);
            this.textBox_EmpPosition.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Должность";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(314, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(756, 422);
            this.dataGridView1.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(311, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(374, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Список подразделений, в котороых работал сотрудник";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(311, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Подразделение";
            // 
            // comboBox_SubDivisionsList
            // 
            this.comboBox_SubDivisionsList.FormattingEnabled = true;
            this.comboBox_SubDivisionsList.Location = new System.Drawing.Point(442, 60);
            this.comboBox_SubDivisionsList.Name = "comboBox_SubDivisionsList";
            this.comboBox_SubDivisionsList.Size = new System.Drawing.Size(610, 24);
            this.comboBox_SubDivisionsList.TabIndex = 12;
            // 
            // button_SaveEmpData
            // 
            this.button_SaveEmpData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_SaveEmpData.Location = new System.Drawing.Point(10, 551);
            this.button_SaveEmpData.Name = "button_SaveEmpData";
            this.button_SaveEmpData.Size = new System.Drawing.Size(136, 32);
            this.button_SaveEmpData.TabIndex = 14;
            this.button_SaveEmpData.Text = "Сохранить";
            this.button_SaveEmpData.UseVisualStyleBackColor = false;
            this.button_SaveEmpData.Click += new System.EventHandler(this.button_SaveEmpData_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Cancel.Location = new System.Drawing.Point(152, 551);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(136, 32);
            this.button_Cancel.TabIndex = 15;
            this.button_Cancel.Text = "Отменить";
            this.button_Cancel.UseVisualStyleBackColor = false;
            // 
            // textBox_TabNumber
            // 
            this.textBox_TabNumber.Location = new System.Drawing.Point(11, 246);
            this.textBox_TabNumber.Name = "textBox_TabNumber";
            this.textBox_TabNumber.Size = new System.Drawing.Size(266, 22);
            this.textBox_TabNumber.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "табельный номер";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(301, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Место рождения";
            // 
            // richTextBox_BirthPlace
            // 
            this.richTextBox_BirthPlace.Location = new System.Drawing.Point(442, 15);
            this.richTextBox_BirthPlace.Name = "richTextBox_BirthPlace";
            this.richTextBox_BirthPlace.Size = new System.Drawing.Size(610, 34);
            this.richTextBox_BirthPlace.TabIndex = 11;
            this.richTextBox_BirthPlace.Text = "";
            // 
            // textBox_INN
            // 
            this.textBox_INN.Location = new System.Drawing.Point(85, 153);
            this.textBox_INN.Name = "textBox_INN";
            this.textBox_INN.Size = new System.Drawing.Size(192, 22);
            this.textBox_INN.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "ИНН";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Дата рождения";
            // 
            // dateTimePicker_BirthDate
            // 
            this.dateTimePicker_BirthDate.Location = new System.Drawing.Point(12, 120);
            this.dateTimePicker_BirthDate.Name = "dateTimePicker_BirthDate";
            this.dateTimePicker_BirthDate.Size = new System.Drawing.Size(269, 22);
            this.dateTimePicker_BirthDate.TabIndex = 31;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 593);
            this.Controls.Add(this.textBox_INN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_BirthDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.richTextBox_BirthPlace);
            this.Controls.Add(this.textBox_TabNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_SaveEmpData);
            this.Controls.Add(this.comboBox_SubDivisionsList);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_EmpPosition);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox_Fired);
            this.Controls.Add(this.dateTimePicker_FireDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker_StartDateWork);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_Surname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Patronimic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label1);
            this.Name = "EmployeeForm";
            this.Text = "`";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Patronimic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Surname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_female;
        private System.Windows.Forms.RadioButton radioButton_male;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDateWork;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FireDate;
        private System.Windows.Forms.CheckBox checkBox_Fired;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_EmpPosition;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_SubDivisionsList;
        private System.Windows.Forms.Button button_SaveEmpData;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_TabNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBox_BirthPlace;
        private System.Windows.Forms.TextBox textBox_INN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_BirthDate;
    }
}