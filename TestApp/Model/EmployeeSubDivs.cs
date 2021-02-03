using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model
{
    public class EmployeeSubDivs
    {
        public EmployeeSubDivs()
        {
            TransferDate = DateTime.Now;
            Position = "";
            SubDivisions = new ObservableCollection<SubDivision>();
        }

        [Column(TypeName = "datetime2")]
        public DateTime TransferDate { get; set; }

        [Column("Position", TypeName = "ntext")]
        [MaxLength(50)]
        public string Position { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ObservableCollection <SubDivision >SubDivisions { get; set; }
    }
}
