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
            comboBox_SubDivisionsList.SelectedIndexChanged += comboBox_SubDivisionsList_SelectedIndexChanged;
        }

        //for edit imployee
        public EmployeeForm(int empId, int subDivId)
        {
            InitializeComponent();
            //editEmployee = true;
            //SubDivRecords = new ObservableCollection<SubDivision>();
            //PreviosLoadData(empId, subDivId);
            //SetDefaultControlsEditEmployee();
            //this.Text = "Режим редактирования данных по сотруднику";
            //checkBox_Fired.CheckedChanged += checkBox_Fired_CheckedChanged;
            //comboBox_SubDivisionsList.SelectedIndexChanged += comboBox_SubDivisionsList_SelectedIndexChanged;
        }
        SubDivision SelectedSubDivision { get; set; }
        SubDivision TransferSubDivision { get; set; }
        Employee SelectedEmployee { get; set; }
        ObservableCollection<SubDivision> SubDivRecords;
        bool editEmployee = false;

        private void SaveNewEmployeeData()
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {

                   // db.Entry(TransferSubDivision).State = EntityState.Modified;

                    if (editEmployee)
                        SelectedEmployee = db.Employees.Where(e => e.EmployeeId == SelectedEmployee.EmployeeId).FirstOrDefault();
                    //else
                    //    db.Employees.Attach(SelectedEmployee);

                   

                    SelectedEmployee.EmpName = textBox_Name.Text;
                    SelectedEmployee.EmpSurName = textBox_Surname.Text;
                    SelectedEmployee.EmpPatronimic = textBox_Patronimic.Text;
                    if (radioButton_male.Checked)
                        SelectedEmployee.Sex = true;
                    if (radioButton_female.Checked)
                        SelectedEmployee.Sex = false;
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

                   


                    //кастыли, которые не также не работают, но если их применить, то получаем 
                    //дублирование название подразделения в БД. Что говорит о том, что нужно как-то умудриться
                    //подифицировать это подразделение.. Пока - хз как. Т.к. связ подразделения и сотрудника у нас 
                    //посрдедством n - n, и с какого-то хера из подразделения не видно сотрудника, хотя и все 
                    //нужные поля  - публичные . жопа кароч
                    //db.Configuration.AutoDetectChangesEnabled = false;
                    //db.Configuration.ValidateOnSaveEnabled = false;


                    if (editEmployee)
                        db.Entry(SelectedEmployee).State = EntityState.Modified;
                    else
                    
                       
                        db.Employees.Add(SelectedEmployee);
                    


                    db.SaveChanges();

                    EmployeeSubDivs empSabDiv = new EmployeeSubDivs();
                    empSabDiv.Employee = SelectedEmployee;
                    empSabDiv.SubDivision = TransferSubDivision;
                    empSabDiv.Position = textBox_EmpPosition.Text;
                    empSabDiv.TransferDate = dateTimePicker_StartDateWork.Value;
                    

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
                        SubDivRecords.Add(
                        new SubDivision
                        {
                            SubDivisionId = item.SubDivisionId,
                            SubDivName = item.SubDivName,
                            ParentIdent = item.ParentIdent,
                            ParentSubdiv = item.ParentSubdiv,
                            CollapsDate = item.CollapsDate,
                            CreateDate = item.CreateDate
                        });
                    }
                    SelectedSubDivision = SubDivRecords.Where(e => e.SubDivisionId == subId).FirstOrDefault();
                    TransferSubDivision = SelectedSubDivision;
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
                    SelectedEmployee = db.Employees.Where(e => e.EmployeeId == empId).FirstOrDefault();           

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



           textBox_Name.Text = "Иван";
           textBox_Surname.Text = "Петров";
            textBox_Patronimic.Text = "Григорьевич";            
                SelectedEmployee.Sex = true;

            dateTimePicker_BirthDate.Value = new DateTime(1984, 1, 1);
            richTextBox_BirthPlace.Text = "Украина, г.Киев";
            textBox_INN.Text= "3087302994" ;
            textBox_TabNumber.Text = TabNumberFill();
            dateTimePicker_StartDateWork.Value = DateTime.Now;
            textBox_EmpPosition.Text = "горе-программист";
            checkBox_Fired.Checked = false;
           


            dateTimePicker_FireDate.Enabled = false;
           richTextBox1.Enabled = false;
            //textBox_TabNumber.Text = TabNumberFill();

            SubDivRecords = new ObservableCollection<SubDivision>(SubDivRecords.OrderBy(e => e.SubDivName));
            comboBox_SubDivisionsList.DataSource = null;
            comboBox_SubDivisionsList.DataSource = SubDivRecords;
            comboBox_SubDivisionsList.DisplayMember = "SubDivName";
            comboBox_SubDivisionsList.ValueMember = "SubDivisionId";
            comboBox_SubDivisionsList.SelectedItem = SelectedSubDivision;
            comboBox_SubDivisionsList.SelectedItem = SubDivRecords.Where(e => e.SubDivisionId == TransferSubDivision.SubDivisionId).FirstOrDefault();
        }

        //for edit employee data
        private void SetDefaultControlsEditEmployee()
        {
            //textBox_Surname.Text = SelectedEmployee.EmpSurName;
            //textBox_Name.Text = SelectedEmployee.EmpName;
            //textBox_Patronimic.Text = SelectedEmployee.EmpPatronimic;
            //textBox_TabNumber.Text = SelectedEmployee.TabNumber;
            //if (SelectedEmployee.sex)
            //    radioButton_male.Checked = true;
            //else
            //    radioButton_female.Checked = true;
            //dateTimePicker_BirthDate.Value = SelectedEmployee.DateBirth;
            //textBox_INN.Text = SelectedEmployee.INN;
            //dateTimePicker_StartDateWork.Value = SelectedEmployee.StartDateWork;

            //if (SelectedEmployee.FireDate == new DateTime(2050, 1, 1))
            //{
            //    dateTimePicker_FireDate.Enabled = false;
            //    richTextBox1.Enabled = false;
            //}
            //else
            //{
            //    dateTimePicker_FireDate.Value = SelectedEmployee.FireDate;
            //    richTextBox1.Enabled = true;
            //    richTextBox1.Text = SelectedEmployee.FireReason;
            //    checkBox_Fired.Checked = true;
            //}

            //richTextBox_BirthPlace.Text = SelectedEmployee.BirthPlace;
            //textBox_EmpPosition.Text = GetEmployeePosition(SelectedEmployee.EmployeeId);

            //SubDivRecords = new ObservableCollection<SubDivision>(SubDivRecords.OrderBy(e => e.SubDivName));
            //comboBox_SubDivisionsList.DataSource = null;
            //comboBox_SubDivisionsList.DataSource = SubDivRecords;
            //SelectedSubDivision = TransferSubDivision;
            //comboBox_SubDivisionsList.DisplayMember = "SubDivName";
            //comboBox_SubDivisionsList.ValueMember = "SubDivisionId";
            //comboBox_SubDivisionsList.SelectedItem = SelectedSubDivision;
        }

        private string GetEmployeePosition(int empId)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    //EmployeeSubDivs emp = db.EmployeeSubDivisions.Where(e => e.Employee.Id == empId).FirstOrDefault();
                    EmployeeSubDivs emp = db.EmployeeSubDivisions.Find(new EmployeeSubDivs() { EmployeeSubDivsId = empId }.EmployeeSubDivsId);
                    return emp.Position;

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
            return null;
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
                SaveNewEmployeeData();
                ShowEmpSubDivs(SelectedEmployee.EmployeeId);
            }



        }

        private void ShowEmpSubDivs(int empId)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                 
                    //dataGridView1.Rows.Clear();
                    //dataGridView1.Columns.Clear();
                    //dataGridView1.Refresh();
                    //List<EmployeeSubDivs> list = db.EmployeeSubDivisions.Where(e => e.Employee.EmployeeId == empId).ToList();
                    //foreach (var item in list)
                    //{
                    //    item.SubDivName = db.SubDivisions.Where(e => e.SubDivisionId == item.SubDivision.SubDivisionId).FirstOrDefault().SubDivName;
                    //}
                    //var source = new BindingSource(list, null);
                    //dataGridView1.DataSource = source;
                    //DataGreedViewUpdate(list);
                    //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

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
           
           // dataGridView1.Columns["EmpSubDivisionId"].Visible = false;
            //dataGridView1.Columns["EmpSubDivision_Id"].Visible = false;
            dataGridView1.Columns["SubDivision"].Visible = false;
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
            if (editEmployee && (dateTimePicker_StartDateWork.Value <= SelectedEmployee.StartDateWork||
                dateTimePicker_StartDateWork.Value>=DateTime.Now.AddDays(1)))
            {
                MessageBox.Show("Дата трансфера не может быть более раней, чем дата устройста на работу\n " +
                    "в предыдущем подразделении. Или будущей датой.");
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

        private void comboBox_SubDivisionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSubDivision = (SubDivision)comboBox_SubDivisionsList.SelectedItem;
        }

        
    }
}
