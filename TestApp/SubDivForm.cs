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

            label4.Text = "";
            this.Text = "Режим создания нового подразделения";
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            ParentSubDiv_comboBox.SelectedIndexChanged += ParentSubDiv_comboBox_SelectedIndexChanged;
        }

        public SubDivForm(SubDivision subDiv)
        {
            InitializeComponent();
            newSubDivSet = false;//set flag in edit mode
            NewdSubDivivsion = subDiv;
            DivRecords = new ObservableCollection<SubDivision>();
            PreviosDataLoad();
            SetDefaultControls(subDiv);
            
            this.Text = "Режим редактирования данных о подразделении";
           
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
            ParentSubDiv_comboBox.DataSource = null;
            ParentSubDiv_comboBox.DataSource = DivRecords;
            
            ParentSubDiv_comboBox.DisplayMember = "SubDivName";
            ParentSubDiv_comboBox.ValueMember = "Id";
            if (NewdSubDivivsion.WorkStatus)
                dateTimePicker2.Visible = false;

            if (newSubDivSet)
            {  
                ParentSubDiv_comboBox.SelectedItem = DivRecords.Where(e => e.Id == 1).FirstOrDefault();               
                dateTimePicker1.Value = NewdSubDivivsion.CreateDate;               
                SubDivName_txtBox.Text = "";
                return;
            }
            if(NewdSubDivivsion.WorkStatus)
            {
                label4.Text = "Работает";
                label4.ForeColor = Color.Green;
                label4.Font = new Font(label4.Font, label4.Font.Style | FontStyle.Bold);
            }
            else
            {
                label4.Text = "Не работает";
                label4.ForeColor = Color.Red;
                label4.Font = new Font(label4.Font, label4.Font.Style | FontStyle.Bold);
            }

            ParentSubDiv_comboBox.SelectedItem = DivRecords.Where(e => e.Id == SelectedSubDivivsion.ParentId).FirstOrDefault();

        }

        private void SetDefaultControls(SubDivision subDiv)
        {
            

            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    SelectedSubDivivsion = db.SubDivisions.Where(e => e.Id == subDiv.ParentId).FirstOrDefault();
                    ParentSubDiv_comboBox.SelectedItem = SelectedSubDivivsion;
                    dateTimePicker1.Value = subDiv.CreateDate;
                    checkBox1.Checked = false;
                    dateTimePicker2.Value = subDiv.CollapsDate;
                    SubDivName_txtBox.Text = subDiv.SubDivName;
                    

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
        //for load data in "new SabDiv" mode
        private void PreviosDataLoad()
        {
            DivRecords.Clear();
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

       
        private void SaveSubDivBtn_Click(object sender, EventArgs e)
        {
            //Close mode
            if (subDivClosed)
            {
                CloseSubdivision();
                return;
            }
            //Edit mode 
            if (!newSubDivSet)
            {
                EditSubdiv();
                return;
            }
            //Add new subdiv mode
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

                    SubDivision tmp = db.SubDivisions.Where(o=>o.Id==NewdSubDivivsion.Id).FirstOrDefault();
                    
                    if (tmp != null)
                    {
                        db.Entry(tmp).State = EntityState.Modified;

                        tmp.SubDivName = SubDivName_txtBox.Text;                        
                        tmp.ParentId = SelectedSubDivivsion.Id;
                        tmp.CreateDate = dateTimePicker1.Value;
                        tmp.CollapsDate = dateTimePicker2.Value;

                        db.SaveChanges();

                        PreviosDataLoad();
                        SetDefaultControls();
                        MessageBox.Show("Данные о подразделении изменены");
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


        private void CloseSubdivision()
        {
            if (dateTimePicker2.Value < NewdSubDivivsion.CreateDate || dateTimePicker2.Value > DateTime.Now)
            {
                MessageBox.Show("Не корректная дата закрытия");
                return;
            }
            using (DBConteiner db = new DBConteiner())
            {
                try
                {
                    SubDivName_txtBox.Enabled = false;                    
                    SubDivision CloseSubdiv = db.SubDivisions.Where(o => o.Id == NewdSubDivivsion.Id).FirstOrDefault();
                    if (CloseSubdiv != null)
                    {
                        db.Entry(CloseSubdiv).State = EntityState.Modified;
                        CloseSubdiv.CollapsDate = dateTimePicker2.Value;
                        CloseSubdiv.WorkStatus = false;
                        //here we change the status of parent subdivision in all of subdivision which have a parent subdivision 
                        //that we close now. New status of these subdivision is "No patent sabdivision"
                        List<SubDivision> subDivisions = db.SubDivisions.Where(e => e.ParentId == NewdSubDivivsion.Id).ToList();
                        if (subDivisions!=null)
                        foreach (SubDivision sub in subDivisions)
                        {
                                db.Entry(sub).State = EntityState.Modified;
                                sub.ParentId = 1;
                        }
                        db.SaveChanges();
                        NewdSubDivivsion.WorkStatus = false;//for corret showing infomation by label4 (Work ort Don't work)
                        PreviosDataLoad();
                        SetDefaultControls();
                        MessageBox.Show("Подразделение закрыто");
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


        //here we only close window, without undoing recent database actions
        private void CancelSubDivBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //here we block field of "Subdivision likvidation date"
            if (checkBox1.Checked)
            {
                dateTimePicker2.Value = DateTime.Now;
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

      

        private void ParentSubDiv_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSubDivivsion = (SubDivision)ParentSubDiv_comboBox.SelectedItem;
        }
    }
}
