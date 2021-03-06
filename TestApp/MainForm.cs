﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;

namespace TestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        List<SubDivision> SubDivRecords;
        SubDivision SelectedSubDiv { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            SubDivRecords = new List<SubDivision>();
            FillSubDivsList();
            AddEmployeesToDB();
            AddEmployeeSubdivsToDB();
            PreviosDataLoad();
           
        }


        //Add Subdivision button
        private void button1_Click(object sender, EventArgs e)
        {
            SubDivForm addNewSubDiv = new SubDivForm();
            addNewSubDiv.ShowDialog();
            PreviosDataLoad();
        }

        //here we fill in previos data to DB
        private void PreviosDataLoad()
        {
            treeView1.Nodes.Clear();
            using (DBConteiner db = new DBConteiner())
            {
                try
                {                    
                    SubDivRecords = new List<SubDivision>( db.SubDivisions.ToList().OrderBy(e => e.SubDivName));                   
                    PopulateTreeView(null, null);
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
        //for previos fill SubDivisions combobox  
        private void FillSubDivsList()
        {
            //using (DBConteiner db = new DBConteiner())
            //{
            //    try
            //    {
            //        //if (db.SubDivisions.Count() == 0)
            //        //{
            //        //    db.SubDivisions.Add(new SubDivision { SubDivName = "Нет родительского подразделения" });
            //        //    db.SubDivisions.Add(new SubDivision { SubDivName = "АМКР", CreateDate = new DateTime(1937, 1,10) });
            //        //    db.SubDivisions.Add(new SubDivision { SubDivName = "ЦГОК", CreateDate = new DateTime(1948, 3, 8) });
            //        //    db.SubDivisions.Add(new SubDivision { SubDivName = "КЖРК", CreateDate = new DateTime(1958, 8, 16) });
            //        //    db.SubDivisions.Add(new SubDivision { SubDivName = "ИНГОК", CreateDate = new DateTime(1955, 12, 9) });
            //        //    db.SubDivisions.Add(new SubDivision { SubDivName = "Метинвест", CreateDate = new DateTime(2000, 5, 15) });
            //        //    db.SaveChanges();
            //        //}
            //    }
            //    catch (ArgumentNullException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (OverflowException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.SqlClient.SqlException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.Entity.Core.EntityException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        //for previos DB fill 
        private void AddEmployeesToDB()
        {
            //using (DBConteiner db = new DBConteiner())
            //{
            //    try
            //    {
            //        //if (db.Employees.Count() == 0)
            //        //{
            //        //    Employee worker1 = new Employee
            //        //    {
            //        //        EmpName = "Иван",
            //        //        EmpSurName = "Петров",
            //        //        EmpPatronimic = "Эдуардович",
            //        //        TabNumber = "1254523OL",
            //        //        DateBirth = new DateTime(1981, 1, 10),
            //        //        StartDateWork = new DateTime(2020, 6, 1),
            //        //        BirthPlace = "Украина, г.Киев",
            //        //        INN = "2058746322"
            //        //    };

            //        //    worker1.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();

            //        //    db.Employees.Add(worker1);

            //        //    Employee worker2 = new Employee
            //        //    {
            //        //        EmpName = "Максим",
            //        //        EmpSurName = "Сидоров",
            //        //        EmpPatronimic = "Иванович",
            //        //        TabNumber = "52545965K",
            //        //        DateBirth = new DateTime(1984, 1, 11),
            //        //        StartDateWork = new DateTime (2021,2,1),
            //        //        BirthPlace = "Украина, г.Днепр",
            //        //        INN = "5158746330"
            //        //    };
            //        //    worker2.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.Employees.Add(worker2);

            //        //    Employee worker3 = new Employee
            //        //    {
            //        //        EmpName = "Павел",
            //        //        EmpSurName = "Жорин",
            //        //        EmpPatronimic = "Прус",
            //        //        TabNumber = "6524E52521",
            //        //        DateBirth = new DateTime(1976, 3, 9),
            //        //        StartDateWork = new DateTime(2020, 3, 5),
            //        //        BirthPlace = "Украина, г.Харьков",
            //        //        INN = "855885230"
            //        //    };
            //        //    worker3.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.Employees.Add(worker3);

            //        //    Employee worker4 = new Employee
            //        //    {
            //        //        EmpName = "Жанна",
            //        //        EmpSurName = "Петрова",
            //        //        EmpPatronimic = "Кирилловна",
            //        //        TabNumber = "9564E552H",
            //        //        DateBirth = new DateTime(1981, 9, 4),
            //        //        StartDateWork = new DateTime(2019, 3, 4),
            //        //        BirthPlace = "Украина, г.Донецк",
            //        //        INN = "8962446741",
            //        //        sex = false

            //        //    };
            //        //    worker4.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.Employees.Add(worker4);
            //        //    db.Configuration.AutoDetectChangesEnabled = false;
            //        //    db.Configuration.ValidateOnSaveEnabled = false;
            //        //    db.SaveChanges();
            //        //}
            //    }
            //    catch (ArgumentNullException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (OverflowException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.SqlClient.SqlException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.Entity.Core.EntityException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

       //for previos DB fill 
        private void AddEmployeeSubdivsToDB()
        {
            //using (DBConteiner db = new DBConteiner())
            //{
            //    try
            //    {
            //        //if (db.EmployeeSubDivisions.Count() == 0)
            //        //{

            //        //    EmployeeSubDivs empSD1 = new EmployeeSubDivs
            //        //    {
            //        //        Position = "программист",
            //        //        TransferDate = db.Employees.Where(e => e.EmployeeId == 1).FirstOrDefault().StartDateWork,
                            
            //        //        Employee = db.Employees.Where(e => e.EmployeeId == 1).FirstOrDefault()
            //        //    };
            //        //    empSD1.SubDivision = db.SubDivisions.Where(e=>e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.EmployeeSubDivisions.Add(empSD1);

            //        //    EmployeeSubDivs empSD2 = new EmployeeSubDivs
            //        //    {
            //        //        Position = "программист",
            //        //        TransferDate = db.Employees.Where(e => e.EmployeeId == 2).FirstOrDefault().StartDateWork,
                       
            //        //        Employee = db.Employees.Where(e => e.EmployeeId == 2).FirstOrDefault()
            //        //    };
            //        //    empSD2.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.EmployeeSubDivisions.Add(empSD2);

            //        //    EmployeeSubDivs empSD3 = new EmployeeSubDivs
            //        //    {
            //        //        Position = "программист",
            //        //        TransferDate = db.Employees.Where(e => e.EmployeeId == 3).FirstOrDefault().StartDateWork,
                            
            //        //        Employee = db.Employees.Where(e => e.EmployeeId == 3).FirstOrDefault()
            //        //    };
            //        //    empSD3.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.EmployeeSubDivisions.Add(empSD3);

            //        //    EmployeeSubDivs empSD4 = new EmployeeSubDivs
            //        //    {
            //        //        Position = "программист",
            //        //        TransferDate = db.Employees.Where(e => e.EmployeeId == 4).FirstOrDefault().StartDateWork,
                           
            //        //        Employee = db.Employees.Where(e => e.EmployeeId == 4).FirstOrDefault()
            //        //    };
            //        //    empSD4.SubDivision = db.SubDivisions.Where(e => e.SubDivisionId == 5).FirstOrDefault();
            //        //    db.EmployeeSubDivisions.Add(empSD4);



            //        //    //db.Configuration.AutoDetectChangesEnabled = false;
            //        //    //db.Configuration.ValidateOnSaveEnabled = false;
            //        //    db.SaveChanges();
            //        //}
            //    }
            //    catch (ArgumentNullException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (OverflowException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.SqlClient.SqlException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (System.Data.Entity.Core.EntityException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }


        //has taken from here 
        //https://blogs.msmvps.com/deborahk/populating-a-treeview-control-from-a-list/
        private void PopulateTreeView(int? parentId, TreeNode parentNode)
        {
            var filteredItems = SubDivRecords.Where(item =>
                                        item.ParentIdent == parentId);

            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                if (parentNode == null)
                {
                    childNode = treeView1.Nodes.Add(i.SubDivName);
                    childNode.Tag = i.SubDivisionId;
                }
                else
                {
                    childNode = parentNode.Nodes.Add(i.SubDivName);
                    childNode.Tag = i.SubDivisionId;
                }

                PopulateTreeView(i.SubDivisionId, childNode);
            }
        }


        private void SubDivEditBtn_Click(object sender, EventArgs e)
        {
            
            if (SelectedSubDiv == null)
                MessageBox.Show("Нужно выбрать подразделение");
            else
            {
                SubDivForm addNewSubDiv = new SubDivForm(SelectedSubDiv);                
                addNewSubDiv.ShowDialog();
                PreviosDataLoad();
            }
            
        }

        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            int Id = (int)treeView1.SelectedNode.Tag;
            GetSelectedSubDiv(Id);
            GetEmployees(Id);
        }

        private void GetSelectedSubDiv(int Id)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    SelectedSubDiv = db.SubDivisions.Where(item => item.SubDivisionId == Id).FirstOrDefault();
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

        //for filling datagridview
        private void GetEmployees(int Id)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    List<Employee> empList = db.Employees.Where(e => e.EmployeeSubDivisions.Where(i=>i.SubDivisionId==Id).FirstOrDefault().SubDivisionId==Id).ToList();                    
                    var source = new BindingSource(empList, null);
                    dataGridView1.DataSource = source;
                    DataGreedViewUpdate(empList);
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

        private void DataGreedViewUpdate(List<Employee> empList)
        {
            dataGridView1.Columns.Add(new DataGridViewColumn { HeaderText = "пол", Name = "пол", CellTemplate = new DataGridViewTextBoxCell() });
            int i = 0;
            foreach (Employee emp in empList)
            {
                if (emp.Sex)
                    dataGridView1["пол", i].Value = "муж";
                else
                    dataGridView1["пол", i].Value = "жен";
                i++;
            }
            i = 0;
            dataGridView1.Columns.Add(new DataGridViewColumn { HeaderText = "Дата увольнения", Name = "FireDate2", CellTemplate = new DataGridViewTextBoxCell() });
            foreach (Employee emp in empList)
            {
                if (emp.FireDate == new DateTime(2050, 1, 1))
                    dataGridView1["FireDate2", i].Value = "работает";
                else
                    dataGridView1["FireDate2", i].Value = emp.FireDate.ToString("MM/dd/yyyy");
                i++;
            }
            dataGridView1.Columns["EmployeeId"].Visible = false;
            dataGridView1.Columns["EmployeeSubDivisions"].Visible = false;
            dataGridView1.Columns["Sex"].Visible = false;
            dataGridView1.Columns["FireDate"].Visible = false;

            dataGridView1.Columns["TabNumber"].DisplayIndex = 5;
            dataGridView1.Columns["EmpName"].DisplayIndex = 2;
            dataGridView1.Columns["EmpSurname"].DisplayIndex = 1;
            dataGridView1.Columns["EmpPatronimic"].DisplayIndex = 3;
            dataGridView1.Columns["FireDate2"].DisplayIndex = 10;
            dataGridView1.Columns["пол"].DisplayIndex = 4;

            //dataGridView1.Columns["DateBirth"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView1.Columns["StartDateWork"].DefaultCellStyle.Format = "MM/dd/yyyy";
            //dataGridView1.Columns["FireDate2"].DefaultCellStyle.Format = "MM/dd/yyyy";

            dataGridView1.Columns["TabNumber"].HeaderText = "Табельный номер";
            dataGridView1.Columns["EmpName"].HeaderText = "Имя";
            dataGridView1.Columns["EmpSurName"].HeaderText = "Фамилия";
            dataGridView1.Columns["EmpPatronimic"].HeaderText = "Отчество";
            dataGridView1.Columns["DateBirth"].HeaderText = "Дата рождения";
            dataGridView1.Columns["BirthPlace"].HeaderText = "Место рождения";
            dataGridView1.Columns["INN"].HeaderText = "ИНН";
            dataGridView1.Columns["StartDateWork"].HeaderText = "Дата начала работы";
            dataGridView1.Columns["FireReason"].HeaderText = "Причина увольнения";
        }

        //add new Employee btn
        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeForm addNewEmp = new EmployeeForm(SelectedSubDiv.SubDivisionId);
            addNewEmp.ShowDialog();
            PreviosDataLoad();
        }

        private void EmployeeEditBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Нужно выделить строку из поля сотрудники");
                return;
            }
            int impId=(int)dataGridView1.SelectedRows[0].Cells[0].Value;
            EmployeeForm addNewEmp = new EmployeeForm(impId , SelectedSubDiv.SubDivisionId);
            addNewEmp.ShowDialog();
        }

     

      

        
    }
}
