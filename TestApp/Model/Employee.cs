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
    public class Employee//: Helpes.ObservableObject
    {
        public Employee()
        {
            this.TabNumber = null;
            this.EmpName = "";
            this.EmpSurName = "";
            this.EmpPatronimic = "";
            this.Sex = true;//true - men, false - woomen            
            this.DateBirth = DateTime.Now;
            this.BirthPlace = "";
            this.INN = "";
            this.StartDateWork = DateTime.Now;
            this.FireDate = new DateTime(2050, 1, 1);
            this.FireReason = "";

            this.EmployeeSubDivisions = new HashSet<EmployeeSubDivs>();
        }
        [Key]
    
        public int EmployeeId { get; set; }

        [Column("TabNumber", TypeName = "ntext")]
        [MaxLength(4)]
        public string TabNumber { get; set; }

        [Column("EmpName", TypeName = "ntext")]
        [MaxLength(50)]
        public string EmpName { get; set; }

        [Column("EmpSurName", TypeName = "ntext")]
        [MaxLength(50)]
        public string EmpSurName { get; set; }

        [Column("EmpPatronimic", TypeName = "ntext")]
        [MaxLength(50)]
        public string EmpPatronimic { get; set; }

        public bool Sex { get; set; }
        

        [Column(TypeName = "datetime2")]
        public DateTime DateBirth { get; set; }

        [Column("BirthPalce", TypeName = "ntext")]
        [MaxLength(500)]
        public string BirthPlace { get; set; }

        [Column("INN", TypeName = "ntext")]
        [MaxLength(10)]
        public string INN { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateWork { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FireDate { get; set; }


        [Column("FireReason", TypeName = "ntext")]
        [MaxLength(500)]
        public string FireReason { get; set; }

     
      
        public virtual ICollection<EmployeeSubDivs> EmployeeSubDivisions { get; set; }
    }
}
