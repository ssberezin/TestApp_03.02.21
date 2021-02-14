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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<SubDivision> SubDivRecords;

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

                    //ниже - полная дичь. тут
                    //https://www.cyberforum.ru/asp-net/thread634911.html
                    //вроде норм. Над будет перенять

                    //parent subdivisions list
                    List<SubDivision> ParentSubdivs = db.SubDivisions.Where(e => e.ParentId == 1).ToList();
                    //children subdivisions list
                    SubDivRecords = db.SubDivisions.Where(e => e.ParentId != 1).ToList();

                    treeView1.Nodes.Clear();
                    SubDivision no = ParentSubdivs.Where(e => e.SubDivName == "Нет родительского подразделения").FirstOrDefault();
                    ParentSubdivs.Remove(no);
                    foreach (SubDivision parent in ParentSubdivs)
                    {
                        
                        TreeNode masterNode = new TreeNode(parent.SubDivName.ToString());
                        treeView1.Nodes.Add(masterNode);

                        foreach (SubDivision child in SubDivRecords)
                        {
                            if (child.ParentId == parent.Id)
                                masterNode.Nodes.Add(new TreeNode(child.SubDivName.ToString()));
                        }
                    }
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

        private void SubDivEditBtn_Click(object sender, EventArgs e)
        {
           //времянка, пока не научился , как вытащить нужное подразделение из дерева
            DBConteiner db = new DBConteiner();
            SubDivision sub = db.SubDivisions.Where(ex => ex.Id == 4).FirstOrDefault();
            SubDivForm addNewSubDiv = new SubDivForm(sub);
            addNewSubDiv.Show();
        }
    }
}
