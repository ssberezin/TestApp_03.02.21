using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;

namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (DBConteiner db = new DBConteiner())
            {
                //if (db.SubDivisions.Count() == 0)
                //{
                //    db.SubDivisions.Add(new SubDivision()
                //    {
                //        SubDivName = "Строй Монтаж",
                //        ParentSubDivName = "АМКР"
                //    });
                //    db.SaveChanges();
                //}
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        }
    }
}
