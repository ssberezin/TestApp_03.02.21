using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();

            this.Text = "Режим оформления нового сотрудника";
        }

        public EmployeeForm(int empId)
        {
            InitializeComponent();

            this.Text = "Режим редактирования данных по сотруднику";
        }

        Employee SelectedEmployee { get; set; }
        List<SubDivision> SubDivRecords;

        private void SaveNewEmployeeData()
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


        private void PreviosLoadData()
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    SubDivRecords = new List<SubDivision>();
                    SubDivRecords = db.SubDivisions.Where(e => e.Id != 1).ToList();
                    comboBox_SubDivisionsList.DataSource = SubDivRecords;

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


        private void PreviosLoadData(int Id)
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    SubDivRecords = new List<SubDivision>();
                    SubDivRecords = db.SubDivisions.Where(e => e.Id != 1).ToList();
                    comboBox_SubDivisionsList.DataSource = SubDivRecords;

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
        }

    }
}
