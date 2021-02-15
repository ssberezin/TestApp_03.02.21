namespace TestApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SubDivisionsPanel = new System.Windows.Forms.Panel();
            this.SubDivEditBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.EmployeesPanel = new System.Windows.Forms.Panel();
            this.EmployeeEditBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SubDivisionsPanel.SuspendLayout();
            this.EmployeesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SubDivisionsPanel
            // 
            this.SubDivisionsPanel.Controls.Add(this.SubDivEditBtn);
            this.SubDivisionsPanel.Controls.Add(this.label1);
            this.SubDivisionsPanel.Controls.Add(this.button1);
            this.SubDivisionsPanel.Controls.Add(this.treeView1);
            this.SubDivisionsPanel.Location = new System.Drawing.Point(12, 12);
            this.SubDivisionsPanel.Name = "SubDivisionsPanel";
            this.SubDivisionsPanel.Size = new System.Drawing.Size(483, 668);
            this.SubDivisionsPanel.TabIndex = 0;
            // 
            // SubDivEditBtn
            // 
            this.SubDivEditBtn.BackColor = System.Drawing.SystemColors.Info;
            this.SubDivEditBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SubDivEditBtn.Location = new System.Drawing.Point(329, 624);
            this.SubDivEditBtn.Name = "SubDivEditBtn";
            this.SubDivEditBtn.Size = new System.Drawing.Size(151, 41);
            this.SubDivEditBtn.TabIndex = 4;
            this.SubDivEditBtn.Text = "Редактировать";
            this.SubDivEditBtn.UseVisualStyleBackColor = false;
            this.SubDivEditBtn.Click += new System.EventHandler(this.SubDivEditBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(188, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Подразделения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(3, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.treeView1.Location = new System.Drawing.Point(3, 22);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(477, 596);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // EmployeesPanel
            // 
            this.EmployeesPanel.Controls.Add(this.dataGridView1);
            this.EmployeesPanel.Controls.Add(this.EmployeeEditBtn);
            this.EmployeesPanel.Controls.Add(this.label2);
            this.EmployeesPanel.Controls.Add(this.button3);
            this.EmployeesPanel.Controls.Add(this.button4);
            this.EmployeesPanel.Location = new System.Drawing.Point(501, 12);
            this.EmployeesPanel.Name = "EmployeesPanel";
            this.EmployeesPanel.Size = new System.Drawing.Size(893, 668);
            this.EmployeesPanel.TabIndex = 1;
            // 
            // EmployeeEditBtn
            // 
            this.EmployeeEditBtn.BackColor = System.Drawing.SystemColors.Info;
            this.EmployeeEditBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EmployeeEditBtn.Location = new System.Drawing.Point(348, 624);
            this.EmployeeEditBtn.Name = "EmployeeEditBtn";
            this.EmployeeEditBtn.Size = new System.Drawing.Size(134, 41);
            this.EmployeeEditBtn.TabIndex = 5;
            this.EmployeeEditBtn.Text = "Редактировать";
            this.EmployeeEditBtn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(162, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сотрудники";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(759, 624);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 41);
            this.button3.TabIndex = 4;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(3, 624);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 41);
            this.button4.TabIndex = 3;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(882, 598);
            this.dataGridView1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 681);
            this.Controls.Add(this.EmployeesPanel);
            this.Controls.Add(this.SubDivisionsPanel);
            this.MaximumSize = new System.Drawing.Size(1424, 728);
            this.MinimumSize = new System.Drawing.Size(1424, 728);
            this.Name = "MainForm";
            this.Text = "Подразделения и сотрудники";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SubDivisionsPanel.ResumeLayout(false);
            this.SubDivisionsPanel.PerformLayout();
            this.EmployeesPanel.ResumeLayout(false);
            this.EmployeesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SubDivisionsPanel;
        private System.Windows.Forms.Panel EmployeesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button SubDivEditBtn;
        private System.Windows.Forms.Button EmployeeEditBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

