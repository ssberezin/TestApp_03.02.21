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
            this.CollapsDate = new DateTime(2050, 1, 1);
            this.CreateDate = DateTime.Now;
            this.SubDivName = "";
            this.ParentSubDivName = "";         

            this.Employees = new ObservableCollection<Employee>();

        }
        public int Id { get; set; }

        [Column("SubDivName", TypeName = "ntext")]
        [MaxLength(500)]
        public string SubDivName { get; set; }

        [Column("ParentSubDivName", TypeName = "ntext")]
        [MaxLength(500)]
        public string ParentSubDivName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CollapsDate { get; set; }

        public virtual ObservableCollection<Employee> Employees { get; set; }
        public virtual EmployeeSubDivs EmployeeSubDiv { get; set; }

    }
}
