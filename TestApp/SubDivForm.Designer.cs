namespace TestApp
{
    partial class SubDivForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ParentSubDiv_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SubDivName_txtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SaveSubDivBtn = new System.Windows.Forms.Button();
            this.CancelSubDivBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 41);
            this.panel1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(136, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Дата создания";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(558, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(421, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Дата закрытия";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ParentSubDiv_comboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SubDivName_txtBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 65);
            this.panel2.TabIndex = 6;
            // 
            // ParentSubDiv_comboBox
            // 
            this.ParentSubDiv_comboBox.FormattingEnabled = true;
            this.ParentSubDiv_comboBox.Location = new System.Drawing.Point(224, 35);
            this.ParentSubDiv_comboBox.Name = "ParentSubDiv_comboBox";
            this.ParentSubDiv_comboBox.Size = new System.Drawing.Size(557, 24);
            this.ParentSubDiv_comboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Родительское подразделение";
            // 
            // SubDivName_txtBox
            // 
            this.SubDivName_txtBox.Location = new System.Drawing.Point(224, 8);
            this.SubDivName_txtBox.Name = "SubDivName_txtBox";
            this.SubDivName_txtBox.Size = new System.Drawing.Size(557, 22);
            this.SubDivName_txtBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наименование подразделения";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CancelSubDivBtn);
            this.panel3.Controls.Add(this.SaveSubDivBtn);
            this.panel3.Location = new System.Drawing.Point(12, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 48);
            this.panel3.TabIndex = 7;
            // 
            // SaveSubDivBtn
            // 
            this.SaveSubDivBtn.BackColor = System.Drawing.Color.YellowGreen;
            this.SaveSubDivBtn.Location = new System.Drawing.Point(3, 3);
            this.SaveSubDivBtn.Name = "SaveSubDivBtn";
            this.SaveSubDivBtn.Size = new System.Drawing.Size(252, 42);
            this.SaveSubDivBtn.TabIndex = 8;
            this.SaveSubDivBtn.Text = "Сохранить";
            this.SaveSubDivBtn.UseVisualStyleBackColor = false;
            // 
            // CancelSubDivBtn
            // 
            this.CancelSubDivBtn.BackColor = System.Drawing.Color.Red;
            this.CancelSubDivBtn.Location = new System.Drawing.Point(524, 3);
            this.CancelSubDivBtn.Name = "CancelSubDivBtn";
            this.CancelSubDivBtn.Size = new System.Drawing.Size(252, 42);
            this.CancelSubDivBtn.TabIndex = 9;
            this.CancelSubDivBtn.Text = "Отменить";
            this.CancelSubDivBtn.UseVisualStyleBackColor = false;
            // 
            // SubDivForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 172);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(818, 219);
            this.MinimumSize = new System.Drawing.Size(818, 219);
            this.Name = "SubDivForm";
            this.Text = "Пдразделение";
            this.Load += new System.EventHandler(this.SubDivForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ParentSubDiv_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubDivName_txtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button CancelSubDivBtn;
        private System.Windows.Forms.Button SaveSubDivBtn;
    }
}