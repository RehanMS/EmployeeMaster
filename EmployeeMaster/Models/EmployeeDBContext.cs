using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace EmployeeMaster.Models
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<DesignationMaster> DesignationMaster { get; set;}
        public DbSet<ParentDetailsModel> ParentDetailies { get; set; }
        public DbSet<RegistrationViewModel> Registrations { get; set; }
    }
}