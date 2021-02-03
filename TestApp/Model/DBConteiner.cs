
using System.Data.Entity;


namespace TestApp.Model
{
    class DBConteiner : DbContext
    {
        public DBConteiner() : base("name=TestAppDB")
        {
           
            Database.SetInitializer<DBConteiner>
             (new DropCreateDatabaseIfModelChanges<DBConteiner>());
        }
       
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SubDivision> SubDivisions { get; set; }
        public virtual DbSet<EmployeeSubDivs> EmployeeSubDivisions { get; set; }

    }
}
