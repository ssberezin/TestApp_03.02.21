using System;
using System.Collections.Generic;
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
            this.WorkStatus = true;
            EmployeeSubDivisions  = new HashSet <EmployeeSubDivs>();
            ChildSubdivs = new HashSet<SubDivision>();
        }
        [Key]       
        
        public int SubDivisionId { get; set; }
        

        [Column("SubDivName", TypeName = "ntext")]
        [MaxLength(500)]
        public string SubDivName { get; set; }

        [ForeignKey ("ParentSubdiv")]
        public int? ParentIdent { get; set; }

        public SubDivision ParentSubdiv { get; set; }
        public bool WorkStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CollapsDate { get; set; }

        public virtual ICollection <EmployeeSubDivs> EmployeeSubDivisions { get; set; }
        public virtual ICollection <SubDivision> ChildSubdivs { get; set; }

    }
}
