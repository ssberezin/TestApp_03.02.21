using System;
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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        List<SubDivision> SubDivRecords;
        SubDivision SelectedSubDiv { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            SubDivRecords = new List<SubDivision>(); 
            PreviosDataLoad();
        }


        //Add Subdivision button
        private void button1_Click(object sender, EventArgs e)
        {
            SubDivForm addNewSubDiv = new SubDivForm();
            addNewSubDiv.Show();
        }

        //here we fill in previos data to DB
        private void PreviosDataLoad()
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {

                    if (db.SubDivisions.Count() == 0)
                    {
                        db.SubDivisions.Add(new SubDivision { SubDivName = "Нет родительского подразделения" });
                        db.SubDivisions.Add(new SubDivision { SubDivName = "АМКР" });
                        db.SubDivisions.Add(new SubDivision { SubDivName = "ЦГОК" });
                        db.SubDivisions.Add(new SubDivision { SubDivName = "КЖРК" });
                        db.SubDivisions.Add(new SubDivision { SubDivName = "ИНГОК" });
                        db.SubDivisions.Add(new SubDivision { SubDivName = "Метинвест" });
                        db.SaveChanges();
                    }

                    if (db.Employees.Count() == 0)
                    {
                        Employee worker1 = new Employee
                        {
                            EmpName = "Иван",
                            EmpSurName= "Петров",
                            EmpPatronimic = "Эдуардович",
                            TabNumber = "1254E523OL",
                            DateBirth = new DateTime (1981,1,10),
                            BirthPalce = "Украина, г.Киев",
                            INN = "20587463229"
                        };
                       
                        worker1.SubDivision = db.SubDivisions.Where(e => e.Id == 5).FirstOrDefault();
                       
                        db.Employees.Add(worker1);

                        Employee worker2 = new Employee
                        {
                            EmpName = "Максим",
                            EmpSurName = "Сидоров",
                            EmpPatronimic = "Иванович",
                            TabNumber = "5254E5965K",
                            DateBirth = new DateTime(1984, 1, 11),
                            BirthPalce = "Украина, г.Днепр",
                            INN = "51587463300"
                        };
                        worker2.SubDivision = db.SubDivisions.Where(e => e.Id == 5).FirstOrDefault();
                        db.Employees.Add(worker2);

                        Employee worker3 = new Employee
                        {
                            EmpName = "Павел",
                            EmpSurName = "Жорин",
                            EmpPatronimic = "Прус",
                            TabNumber = "6524E52521",
                            DateBirth = new DateTime(1986, 3, 9),
                            BirthPalce = "Украина, г.Харьков",
                            INN = "85588523300"
                        };
                        worker3.SubDivision = db.SubDivisions.Where(e => e.Id == 5).FirstOrDefault();
                        db.Employees.Add(worker3);

                        Employee worker4 = new Employee
                        {
                            EmpName = "Жанна",
                            EmpSurName = "Петрова",
                            EmpPatronimic = "Кирлловна",
                            TabNumber = "9564E5252H",
                            DateBirth = new DateTime(1983, 9, 4),
                            BirthPalce = "Украина, г.Донецк",
                            INN = "89624463741",
                            male=false,
                            female=true
                        };
                        worker4.SubDivision = db.SubDivisions.Where(e => e.Id == 5).FirstOrDefault();
                        db.Employees.Add(worker4);
                        db.Configuration.AutoDetectChangesEnabled = false;
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();                       
                    }

                    SubDivRecords = db.SubDivisions.ToList();
                    SubDivision tmp = db.SubDivisions.Where(e => e.Id == 1).FirstOrDefault();
                    SubDivRecords.Remove(tmp);
                    PopulateTreeView(1, null);
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

        //has taken from here 
        //https://blogs.msmvps.com/deborahk/populating-a-treeview-control-from-a-list/
        private void PopulateTreeView(int parentId, TreeNode parentNode)
        {
            var filteredItems = SubDivRecords.Where(item =>
                                        item.ParentId == parentId);

            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                if (parentNode == null)
                {
                    childNode = treeView1.Nodes.Add(i.SubDivName);
                    childNode.Tag = i.Id;
                }
                else
                {
                    childNode = parentNode.Nodes.Add(i.SubDivName);
                    childNode.Tag = i.Id;
                }

                PopulateTreeView(i.Id, childNode);
            }
        }


        private void SubDivEditBtn_Click(object sender, EventArgs e)
        {
            //времянка, пока не научился , как вытащить нужное подразделение из дерева
            // DBConteiner db = new DBConteiner();
            //SubDivision sub = db.SubDivisions.Where(ex => ex.Id == 4).FirstOrDefault();
            if (SelectedSubDiv == null)
                MessageBox.Show("Нужно выбрать подразделение");
            else
            {
                SubDivForm addNewSubDiv = new SubDivForm(SelectedSubDiv);
                addNewSubDiv.Show();
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
                    SelectedSubDiv = db.SubDivisions.Where(item => item.Id == Id).FirstOrDefault();
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

        private void GetEmployees(int Id)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    dataGridView1.DataSource = null;
                    List<Employee> empList = db.Employees.Where(e => e.SubDivision.Id == Id).ToList();
                    var source = new BindingSource(empList,null);
                    dataGridView1.DataSource = source;
                    dataGridView1.Columns["Id"].Visible = false;
                    //dataGridView1.Columns[0].DisplayIndex = 2;
                    //dataGridView1.Columns[1].HeaderText = "Табельный номер";
                    //dataGridView1.Columns[2].HeaderText = "Имя";
                    //dataGridView1.Columns[3].HeaderText = "Фамилия";
                    //dataGridView1.Columns[4].HeaderText = "Отчество";
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

    }
}
