
using System.Data.Entity;


namespace TestApp.Model
{
    class DBConteiner : DbContext
    {
        public DBConteiner() : base("name=TestAppDB")
        {
            //Database.SetInitializer<DBConteiner>
            //(new SergeDbCInit());

            Database.SetInitializer<DBConteiner>
             (new DropCreateDatabaseIfModelChanges<DBConteiner>());
        }
       
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SubDivision> SubDivisions { get; set; }
        public virtual DbSet<EmployeeSubDivs> EmployeeSubDivisions { get; set; }

        //public class SergeDbCInit : DropCreateDatabaseIfModelChanges<DBConteiner>
        //{
        //    protected override void Seed(DBConteiner context)
        //    {
        //        base.Seed(context);
        //        context.SubDivisions.Add(new SubDivision { SubDivName = "Programmers" });
        //    }
        //}

    }
}
