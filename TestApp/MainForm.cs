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
        }


        //Add Subdivision button
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
