using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Models;

namespace AvcolStaff.Data
{
    public class AvcolStaffContext : DbContext
    {
        public AvcolStaffContext (DbContextOptions<AvcolStaffContext> options)
            : base(options)
        {
        }

        public DbSet<AvcolStaff.Models.Staff> Staff { get; set; }

        public DbSet<AvcolStaff.Models.Salary> Salary { get; set; }

        public DbSet<AvcolStaff.Models.Standards> Standards { get; set; }

        public DbSet<AvcolStaff.Models.Subjects> Subjects { get; set; }

        public DbSet<AvcolStaff.Models.Departments> Departments { get; set; }
    }
}
