using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;

namespace TestApp
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm(int subDivId)
        {
            InitializeComponent();

            SubDivRecords = new ObservableCollection<SubDivision>();
            PreviosLoadData(subDivId);
            SetDefaultControls();
            this.Text = "Режим оформления нового сотрудника";
            checkBox_Fired.CheckedChanged += checkBox_Fired_CheckedChanged;
        }

        
        public EmployeeForm(int empId, int subDivId)
        {
            InitializeComponent();

            
            
            
           this.Text = "Режим редактирования данных по сотруднику";
            checkBox_Fired.CheckedChanged += checkBox_Fired_CheckedChanged;
        }
        SubDivision SelectedSubDivision { get; set; }
        Employee SelectedEmployee { get; set; }
        ObservableCollection<SubDivision> SubDivRecords;
        bool mode_newEmp = true;

        private void SaveNewEmployeeData()
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    EmployeeSubDivs empSabDiv = new EmployeeSubDivs();

                    SelectedEmployee.EmpName = textBox_Name.Text;
                    SelectedEmployee.EmpSurName = textBox_Surname.Text;
                    SelectedEmployee.EmpPatronimic = textBox_Patronimic.Text;
                    if (radioButton_male.Checked)
                        SelectedEmployee.sex = true;
                    if (radioButton_female.Checked)
                        SelectedEmployee.sex = false;
                    SelectedEmployee.DateBirth = dateTimePicker_BirthDate.Value;
                    SelectedEmployee.INN = textBox_INN.Text;
                    SelectedEmployee.TabNumber = TabNumberFill();
                    SelectedEmployee.StartDateWork = dateTimePicker_StartDateWork.Value;
                    if (checkBox_Fired.Checked)
                    {
                        SelectedEmployee.FireDate = dateTimePicker_FireDate.Value;
                        SelectedEmployee.FireReason = richTextBox1.Text;
                    }
                    SelectedEmployee.SubDivision = SelectedSubDivision;
                   // //get need employee after adding to DB.  Because there is an option that 
                   // //it must have it own Id. 
                   // //Perhaps it was possible to do without this
                   //// SelectedEmployee = db.Employees.Where(e => e.TabNumber == SelectedEmployee.TabNumber).FirstOrDefault();

                    empSabDiv.SubDivisions.Add(SelectedSubDivision);
                    empSabDiv.Position = textBox_EmpPosition.Text;
                    empSabDiv.TransferDate = dateTimePicker_StartDateWork.Value;

                    SelectedEmployee.EmployeeSubDivisions.Add(empSabDiv);

                    db.Employees.Add(SelectedEmployee);
                    db.SaveChanges();

                   
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void PreviosLoadData(int subId)
        {
            SelectedEmployee = new Employee();
            SubDivRecords.Clear();
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    // DivRecords = new ObservableCollection<SubDivision>(DivRecords.OrderBy(e => e.SubDivName));
                    var list = db.SubDivisions.ToList<SubDivision>();
                    foreach (var item in list)
                    {
                        if (item.Id == 1)
                            continue;
                        SubDivRecords.Add(
                        new SubDivision
                        {
                            Id = item.Id,
                            SubDivName = item.SubDivName,
                            ParentId = item.ParentId,
                            CollapsDate = item.CollapsDate,
                            CreateDate = item.CreateDate
                        });
                    }
                    SelectedSubDivision =SubDivRecords.Where(e=>e.Id== subId).FirstOrDefault();                
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        //for edit operations
        private void PreviosLoadData(int empId, int subId)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                                   

                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void SetDefaultControls()
        {
            dateTimePicker_FireDate.Enabled = false;
            richTextBox1.Enabled = false;

            comboBox_SubDivisionsList.DataSource = SubDivRecords;
            comboBox_SubDivisionsList.DisplayMember = "SubDivName";
            comboBox_SubDivisionsList.ValueMember = "Id";
            comboBox_SubDivisionsList.SelectedItem = SelectedSubDivision;
        }

        private void button_SaveEmpData_Click(object sender, EventArgs e)
        {
            //1. here we check all fields validation
            if (!EmpDataValidation())
                return;
            SaveNewEmployeeData();
            //2. Вносим запись в БД
            //3. сразу отображаем информацию о подразделении и должности сотрудника в нужном поле формы




        }

        //if it is Ok - return true
        private bool EmpDataValidation()
        {
            //name, surname and patronimic filds validation
            if (textBox_Name.Text == "" || textBox_Surname.Text == "" || textBox_Patronimic.Text == "")
            {
                MessageBox.Show("Ни одно из полей ФИО не должно быть пустым");
                return false;
            }

            //INN field validation
            if (textBox_INN.Text == ""|| textBox_INN.Text.Length != 10)
            {
                MessageBox.Show("Поле ИНН не заполненно или заполнено не корректно");
                return false;
            }
            else
            {
                //field INN have got 10 digits and nothing alse
                foreach (char s in textBox_INN.Text)
                { 
                    if ((int)s<48&&(int)s>57)
                        MessageBox.Show("Поле ИНН должно содержать только цифры");
                    return false;
                }
            }
            //Select employee sex validation
            if (!radioButton_male.Checked && !radioButton_female.Checked)
            {                
                MessageBox.Show("Нужно указать пол сотрудника");
                return false;
            }
            
            // Date field validation
            if (DateTime.Now.Year - dateTimePicker_BirthDate.Value.Year < 17)
            {
                MessageBox.Show("Минимальный возраст сотрудника 17 лет");
                return false;
            }

            if (dateTimePicker_StartDateWork.Value < SelectedSubDivision.CreateDate)
            {
                MessageBox.Show("Дата устройства наработу не может быть более раней, чем дата основания подразделения");
                return false;
            }

            if (checkBox_Fired.Checked && dateTimePicker_FireDate.Value < dateTimePicker_StartDateWork.Value||
                dateTimePicker_FireDate.Value>DateTime.Now)
            {
                MessageBox.Show("Дата увольнения не может быть более ранеей,\n чем дата устройства на работу или" +
                    "\n или быть более поздней, чем текущая дата ");
                return false;
            }

            //Employee position field validation
            if ( textBox_EmpPosition.Text=="")
            {
                MessageBox.Show("Поле должности не должнго быть пустым");
                return false;
            }

            return true;
        }

        private void checkBox_Fired_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Fired.Checked)
            {
                dateTimePicker_FireDate.Enabled = true;
                richTextBox1.Enabled = true;
            }
            else
            {
                dateTimePicker_FireDate.Enabled = false;
                richTextBox1.Enabled = false;
            }

        }

        //Fill TABNamber field by randomising
        private string TabNumberFill()
        {
            string result;
            Random rnd = new Random();
            result = rnd.Next(1000, 2000).ToString()+(char)rnd.Next(65,125)+ (char)rnd.Next(65, 125)+ rnd.Next(1000, 2000);
            if (!CheckTabnumber(result))            
                TabNumberFill();
                        
            return result;


        }
        //here we check tabnumber in DB. 
        private bool CheckTabnumber(string tabN)
        {            
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    var res = db.Employees.Where(e => e.TabNumber == tabN).FirstOrDefault();
                    if (res != null)
                        return true;  
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }            
            }
            //MessageBox.Show("Ошибка в генерации табельного номера");
            return false;

        }
    }
}
