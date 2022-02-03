using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModelLibrary;
using System.Data.Entity;

namespace EmployeeDALEFLibrary
{
    class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("conn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Depatments { get; set; }
    }
}
