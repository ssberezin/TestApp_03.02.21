using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;

namespace TestApp.Helpes
{
    public class Library
    {
        public bool EmptyField(string param)
        {
            if (param == "")
                return false;
            else
                return true;             
        }

        public bool NewSubDivValidstion(SubDivision newSubDiv)
        {
            bool result = true;

            if (!EmptyField(newSubDiv.SubDivName))
            {
                MessageBox.Show("Поле названия предприятия не должно быть пустым");
                return false;
            }
            if (newSubDiv.CollapsDate<newSubDiv.CreateDate)
            {
                MessageBox.Show("Дата закрытия не может быть более ранеей , чем дата его создания");
                return false;
            }
            return result;
        }

    }
}
