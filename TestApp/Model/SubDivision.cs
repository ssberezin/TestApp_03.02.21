using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestApp.Model
{
    public class SubDivision
    {
        public SubDivision()
        {
            this.CollapsDate = DateTime.Now; 
            this.CreateDate = DateTime.Now;
            this.SubDivName = "";
            this.ParentIdent = 1;
            this.WorkStatus = true;
            this.Employees = new ObservableCollection<Employee>();
           // this.EmployeeSubDivs = new ObservableCollection<EmployeeSubDivs>();
        }
          [Key]
        
        
        public int SubDivisionId { get; set; }
        

        [Column("SubDivName", TypeName = "ntext")]
        [MaxLength(500)]
        public string SubDivName { get; set; }

        public int ParentIdent { get; set; }

        public bool WorkStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CollapsDate { get; set; }

        public virtual ObservableCollection<Employee> Employees { get; set; }
        public virtual ObservableCollection<EmployeeSubDivs> EmployeeSubDivs { get; set; }

    }
}
