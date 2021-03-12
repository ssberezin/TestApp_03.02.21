using System;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestApp.Model
{
    public class EmployeeSubDivs
    {
        public EmployeeSubDivs()
        {
            TransferDate = DateTime.Now;
            Position = "";
            //SubDivName = "";            
        }

        [Key]
        
        public int EmployeeSubDivsId { get; set; }  

        [Column(TypeName = "datetime2")]
        public DateTime TransferDate { get; set; }

        [Column("Position", TypeName = "ntext")]
        [MaxLength(100)]
        public string Position { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("SubDivision")]
        public int SubDivisionId { get; set; }

        public virtual Employee Employee { get; set; }        
        public virtual SubDivision SubDivision { get; set; }
    }
}
