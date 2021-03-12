
using System.Data.Entity;


namespace TestApp.Model
{
    class DBConteiner : DbContext
    {
        public DBConteiner() : base("name=TestAppDB")
        {
            Database.SetInitializer<DBConteiner>
            (new SergeDbCInit());

            //Database.SetInitializer<DBConteiner>
            // (new DropCreateDatabaseIfModelChanges<DBConteiner>());
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
        public class SergeDbCInit : DropCreateDatabaseIfModelChanges<DBConteiner>
        {
            protected override void Seed(DBConteiner context)
            {
                base.Seed(context);
                SubDivision dep1 = context.SubDivisions.Add(new SubDivision { SubDivName = "Programmers" });
                SubDivision dep2 = context.SubDivisions.Add(new SubDivision { SubDivName = "PHP", ParentSubdiv = dep1 });
                SubDivision dep3 = context.SubDivisions.Add(new SubDivision { SubDivName = "C#", ParentSubdiv = dep1 });
                SubDivision dep4 = context.SubDivisions.Add(new SubDivision { SubDivName = "JS", });
                SubDivision dep5 = context.SubDivisions.Add(new SubDivision { SubDivName = "React", ParentSubdiv = dep4 });
                SubDivision dep6 = context.SubDivisions.Add(new SubDivision { SubDivName = "Vue.JS", ParentSubdiv = dep4 });
                SubDivision dep7 = context.SubDivisions.Add(new SubDivision { SubDivName = "Laravel", ParentSubdiv = dep2 });
                SubDivision dep8 = context.SubDivisions.Add(new SubDivision { SubDivName = "CodeIgniter", ParentSubdiv = dep2 });
                SubDivision dep9 = context.SubDivisions.Add(new SubDivision { SubDivName = "Economics" });
                SubDivision dep10 = context.SubDivisions.Add(new SubDivision { SubDivName = "Marketing" });
                context.SaveChanges();
                Employee employee1 = new Employee
                {
                    EmpName = "Иван",
                    EmpSurName = "Иванов",
                    EmpPatronimic = "Иванович",
                    BirthPlace = "Киев",
                    DateBirth = new System.DateTime(1987, 5, 23),
                    FireDate = System.DateTime.Now.AddDays(+50),
                    FireReason = "расдолбай",
                    INN = "1234567899",
                    Sex = true,
                    StartDateWork = System.DateTime.Now.AddDays(-50),
                    TabNumber = "23"
                };
                Employee employee2 = new Employee
                {
                    EmpName = "Кирилл",
                    EmpSurName = "Романов",
                    EmpPatronimic = "Николаевич",
                    BirthPlace = "Киев",
                    DateBirth = new System.DateTime(1985, 2, 12),
                    FireDate = System.DateTime.Now.AddDays(+150),
                    FireReason = "родину не любит",
                    INN = "1234567890",
                    Sex = true,
                    StartDateWork = System.DateTime.Now.AddDays(-50),
                    TabNumber = "41"
                };
                context.Employees.AddRange(new[] { employee1, employee2 });
                context.SaveChanges();
                EmployeeSubDivs empDep1 = new EmployeeSubDivs { Employee = employee1, SubDivision = dep1, Position = "Стажер", TransferDate = System.DateTime.Now.AddDays(-50) };
                EmployeeSubDivs empDep2 = new EmployeeSubDivs { Employee = employee1, SubDivision = dep2, Position = "Младшой PHP программер", TransferDate = System.DateTime.Now.AddDays(-30) };
                EmployeeSubDivs empDep3 = new EmployeeSubDivs { Employee = employee1, SubDivision = dep7, Position = "Мидл PHP программер", TransferDate = System.DateTime.Now.AddDays(+5) };
                EmployeeSubDivs empDep4 = new EmployeeSubDivs { Employee = employee2, SubDivision = dep4, Position = "Стажер", TransferDate = System.DateTime.Now.AddDays(-70) };
                EmployeeSubDivs empDep5 = new EmployeeSubDivs { Employee = employee2, SubDivision = dep5, Position = "Младшой PHP программер", TransferDate = System.DateTime.Now.AddDays(-20) };
                context.EmployeeSubDivisions.AddRange(new[] { empDep1, empDep2, empDep3, empDep4, empDep5 });
                context.SaveChanges();
            }
        }
    }
}
