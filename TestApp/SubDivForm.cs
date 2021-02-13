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
using TestApp.Helpes;
using TestApp.Model;

namespace TestApp
{
    public partial class SubDivForm : Form
    {
        public SubDivForm()
        {
            InitializeComponent();
            DivRecords = new ObservableCollection<SubDivision>();
            NewdSubDivivsion = new SubDivision();
            PreviosDataLoad();
            

            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            ParentSubDiv_comboBox.SelectedIndexChanged += ParentSubDiv_comboBox_SelectedIndexChanged;
        }

        public SubDivForm(SubDivision subDiv)
        {
            InitializeComponent();
            newSubDivSet = false;//set flag in edit mode
            SelectedSubDivivsion = subDiv;
            DivRecords = new ObservableCollection<SubDivision>();
            PreviosDataLoad();
            ParentSubDiv_comboBox.SelectedItem = subDiv;
            //  ParentSubDiv_comboBox.SelectedItem = DivRecords.Where(e => e.Id == subDiv.Id).FirstOrDefault();
            dateTimePicker1.Value = subDiv.CreateDate;
            if (subDiv.CollapsDate == new DateTime(2050, 1, 1))
            {
                dateTimePicker2.Visible = false;
                checkBox1.Checked = false;
            }
            dateTimePicker2.Value = subDiv.CollapsDate;
            SubDivName_txtBox.Text = subDiv.SubDivName;

            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            ParentSubDiv_comboBox.SelectedIndexChanged += ParentSubDiv_comboBox_SelectedIndexChanged;
        }

        public ObservableCollection <SubDivision> DivRecords { get; set; }
        public SubDivision SelectedSubDivivsion { get; set; }
        public SubDivision NewdSubDivivsion { get; set; }
        public bool newSubDivSet = true,
                    subDivClosed=false;

        private void SubDivForm_Load(object sender, EventArgs e)
        {
            SetDefaultControls();
        }

        private void SetDefaultControls()
        {
          
            DivRecords = new ObservableCollection<SubDivision>(DivRecords.OrderBy(e => e.SubDivName));
            ParentSubDiv_comboBox.Items.Clear();
            ParentSubDiv_comboBox.DataSource = DivRecords;
            
            ParentSubDiv_comboBox.DisplayMember = "SubDivName";
            ParentSubDiv_comboBox.ValueMember = "Id";

            dateTimePicker2.Visible = false;

            if (newSubDivSet)
            {  
                ParentSubDiv_comboBox.SelectedItem = DivRecords.Where(e => e.Id == 1).FirstOrDefault();               
                dateTimePicker1.Value = NewdSubDivivsion.CreateDate;
                dateTimePicker2.Value = NewdSubDivivsion.CollapsDate;
                SubDivName_txtBox.Text = "";
            }
        }
        //for load data in "new SabDiv" mode
        private void PreviosDataLoad()
        {
            using (DBConteiner db = new DBConteiner())
            {
                try
                {                  

                   var list = db.SubDivisions.ToList<SubDivision>();
                    foreach (var item in list)
                    {
                        DivRecords.Add(
                        new SubDivision
                        {
                            Id = item.Id,
                            SubDivName = item.SubDivName,
                            ParentId=item.ParentId,
                            CollapsDate=item.CollapsDate,
                            CreateDate=item.CreateDate
                        });
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

       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //here we block field of "Subdivision likvidation date"
            if (checkBox1.Checked)
            {
                dateTimePicker2.Visible = true;
                subDivClosed = true;
            }
            else
            {
                dateTimePicker2.Visible = false;
                //dateTimePicker2.Value = NewdSubDivivsion.CollapsDate;
                subDivClosed = false;
            }
        }

        private void SaveSubDivBtn_Click(object sender, EventArgs e)
        {
            if (!newSubDivSet)
            {
                //тут проходим валидацию
                //тут прописываем процедуру редактирования

                ParentSubDiv_comboBox.DataSource = null;
                DivRecords.Clear();
                PreviosDataLoad();
                return;
            }

            AddNewSubDiv();

        }

        private void AddNewSubDiv()
        {

            NewdSubDivivsion.SubDivName = SubDivName_txtBox.Text;
            NewdSubDivivsion.ParentId = SelectedSubDivivsion.Id;
            NewdSubDivivsion.CreateDate = dateTimePicker1.Value;
            NewdSubDivivsion.CollapsDate = dateTimePicker2.Value;
            Library lib = new Library();
            if (!lib.NewSubDivValidstion(NewdSubDivivsion))
                return;
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    db.SubDivisions.Add(NewdSubDivivsion);
                    db.SaveChanges();
                    ParentSubDiv_comboBox.DataSource = null;
                    //DivRecords.Clear();
                    PreviosDataLoad();//update ParentSubDiv_comboBox content 
                    SetDefaultControls();
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

        private void EditSubdiv()
        {
          
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    Library lib = new Library();
                    if (!lib.NewSubDivValidstion(SelectedSubDivivsion))
                        return;

                    SubDivision tmp = db.SubDivisions.Where(o=>o.Id==SelectedSubDivivsion.Id).FirstOrDefault();
                    
                    if (tmp != null)
                    {
                        db.Entry(tmp).State = EntityState.Modified;

                        tmp.SubDivName = SubDivName_txtBox.Text;
                        tmp.ParentId = SelectedSubDivivsion.Id;
                        tmp.CreateDate = dateTimePicker1.Value;
                        tmp.CollapsDate = dateTimePicker2.Value;

                        db.SaveChanges();

                        ParentSubDiv_comboBox.DataSource = null;
                        DivRecords.Clear();
                        PreviosDataLoad();
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


        private void CancelSubDivBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ParentSubDiv_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SelectedSubDivivsion = (SubDivision)ParentSubDiv_comboBox.SelectedItem;

        }
    }
}
