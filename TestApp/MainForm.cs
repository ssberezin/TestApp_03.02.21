using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //DBConteiner db = new DBConteiner();
            //db.SubDivisions.Add(new SubDivision { SubDivName="АМКР"});
            //db.SaveChanges();
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
                        db.SaveChanges();
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
