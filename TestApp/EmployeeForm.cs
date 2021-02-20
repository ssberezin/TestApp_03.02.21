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
        //for add new employee
        public EmployeeForm(int subDivId)
        {
            InitializeComponent();

            SubDivRecords = new ObservableCollection<SubDivision>();
            PreviosLoadData(subDivId);
            SetDefaultControls();
            this.Text = "Режим оформления нового сотрудника";
            checkBox_Fired.CheckedChanged += checkBox_Fired_CheckedChanged;
        }

        //for edit imployee
        public EmployeeForm(int empId, int subDivId)
        {
            InitializeComponent();
            editEmployee = true;
            SubDivRecords = new ObservableCollection<SubDivision>();
            PreviosLoadData(empId, subDivId);

            //SetDefaultControls();

            this.Text = "Режим редактирования данных по сотруднику";
            checkBox_Fired.CheckedChanged += checkBox_Fired_CheckedChanged;
        }
        SubDivision SelectedSubDivision { get; set; }
        Employee SelectedEmployee { get; set; }
        ObservableCollection<SubDivision> SubDivRecords;
        bool editEmployee = false;

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
                    SelectedEmployee.BirthPlace = richTextBox_BirthPlace.Text;
                    SelectedEmployee.INN = textBox_INN.Text;
                    SelectedEmployee.TabNumber = textBox_TabNumber.Text;
                    SelectedEmployee.StartDateWork = dateTimePicker_StartDateWork.Value;
                    if (checkBox_Fired.Checked)
                    {
                        SelectedEmployee.FireDate = dateTimePicker_FireDate.Value;
                        SelectedEmployee.FireReason = richTextBox1.Text;
                    }
                    //SelectedEmployee.SubDivision = SelectedSubDivision;//эта хрень работает не корректно
                    //если оставить ее как есть, то добавляет новое подразделение
                    //есть мнение, что нужно реализовать механизм клонирования.
                    //возможно, что не происходит глубокое копирование при таком подходе
                    //пришлось лезть в БД за тем, что по сути у нас уже есть (
                    SelectedEmployee.SubDivision = db.SubDivisions.Where(e => e.Id == SelectedSubDivision.Id).FirstOrDefault();
                    

                    //без этих фич не хочет корректно добавлять запись в БД
                    //хотя в MainForm.cs , если посмотреть в строки 89 и 88 , то видим, что все ок и все добавляется
                    //без этих кастылей...
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Employees.Add(SelectedEmployee);

                    db.SaveChanges();

                    // //get need employee after adding to DB.  Because there is an option that 
                    // //it must have it own Id. 
                    // //Perhaps it was possible to do without this                    

                    //нижний огород пришлось городить от того, что ентити с какого-то хрена не желает искать по строкам...
                    //ппц какой-то
                    //get just now added employee from DB, but now hi hes an Id 
                    List<Employee> Employees = db.Employees.ToList();
                    foreach (Employee item in Employees)
                    {
                        if (item.TabNumber == SelectedEmployee.TabNumber)
                        {
                            SelectedSubDivision.Id = item.SubDivision.Id;
                            break;
                        }
                    }
                    if (SelectedSubDivision.Id == 0)
                    {
                        MessageBox.Show("Что-то с сохранение пошло не так....");
                        return;
                    }

                    empSabDiv.EmpSubDivision_Id = SelectedSubDivision.Id;
                    empSabDiv.Position = textBox_EmpPosition.Text;
                    empSabDiv.TransferDate = dateTimePicker_StartDateWork.Value;                    
                    empSabDiv.Employee = db.Employees.Where(e => e.Id == SelectedEmployee.Id).FirstOrDefault();
                    db.EmployeeSubDivisions.Add(empSabDiv);

                    db.SaveChanges();
                    MessageBox.Show("Данные сохранены");
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
            SubDivRecordsFill(subId);
        }

        private void SubDivRecordsFill(int subId)
        {
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
                    SelectedSubDivision = SubDivRecords.Where(e => e.Id == subId).FirstOrDefault();
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
            
            SubDivRecordsFill(subId);
            ShowEmpSubDivs(empId);

            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    SelectedEmployee = db.Employees.Where(e => e.Id == empId).FirstOrDefault();           

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

        //for add new employee
        private void SetDefaultControls()
        {
            dateTimePicker_FireDate.Enabled = false;
            richTextBox1.Enabled = false;
            textBox_TabNumber.Text = TabNumberFill();

            comboBox_SubDivisionsList.DataSource = SubDivRecords;
            comboBox_SubDivisionsList.DisplayMember = "SubDivName";
            comboBox_SubDivisionsList.ValueMember = "Id";
            comboBox_SubDivisionsList.SelectedItem = SelectedSubDivision;
        }

        private void SetDefaultControlsEditEmployee()
        {
            dateTimePicker_FireDate.Enabled = false;
            richTextBox1.Enabled = false;
            textBox_TabNumber.Text = TabNumberFill();

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

            //2. Add new entrie to DB
            if (!editEmployee)
            {
                SaveNewEmployeeData();
                SetDefaultControls();
            }

            if (editEmployee)
            {

                ShowEmpSubDivs(SelectedEmployee.Id);
            }



        }

        private void ShowEmpSubDivs(int empId)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                 
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    List<EmployeeSubDivs> list = db.EmployeeSubDivisions.Where(e => e.Employee.Id == empId).ToList();
                    foreach (var item in list)
                    {
                        item.SubDivName = db.SubDivisions.Where(e => e.Id == item.EmpSubDivision_Id).FirstOrDefault().SubDivName;
                    }
                    var source = new BindingSource(list, null);
                    dataGridView1.DataSource = source;
                    DataGreedViewUpdate(list);
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

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

        private void DataGreedViewUpdate(List<EmployeeSubDivs> empList)
        {
           
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["EmpSubDivision_Id"].Visible = false;
            dataGridView1.Columns["Employee"].Visible = false;

            dataGridView1.Columns["SubDivName"].DisplayIndex = 0;
            dataGridView1.Columns["TransferDate"].DisplayIndex = 1;
            dataGridView1.Columns["Position"].DisplayIndex = 2;

            dataGridView1.Columns["TransferDate"].DefaultCellStyle.Format = "MM/dd/yyyy";

            dataGridView1.Columns["SubDivName"].HeaderText = "Подразделение";
            dataGridView1.Columns["Position"].HeaderText = "Должность";
            dataGridView1.Columns["TransferDate"].HeaderText = "Дата перевода";
            
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

            //employee sex validation
            if (!radioButton_male.Checked && !radioButton_female.Checked)
            {
                MessageBox.Show("Нужно указать пол сотрудника");
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
                    if ((int)s < 48 && (int)s > 57)
                    {
                        MessageBox.Show("Поле ИНН должно содержать только цифры");
                        return false;
                    }
                }
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

            //Birth place field validation
            if (richTextBox_BirthPlace.Text == "")
            {
                MessageBox.Show("Поле места рождения не должнго быть пустым");
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
            result = rnd.Next(100, 999).ToString()+(char)rnd.Next(65,90)+ (char)rnd.Next(65, 90)+ rnd.Next(100, 999)+ (char)rnd.Next(65, 90)+ rnd.Next(0, 9);
            if (CheckTabnumber(result))            
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
                    List <Employee> Employees  = db.Employees.ToList();
                    foreach(Employee item in Employees)
                        if(item.TabNumber==tabN)                                                
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
