using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.Repository.Domain;

namespace TestAuth.Repository
{
    public class AuthDBContext: DbContext
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataPrivilegeRule>().HasKey(c => new { c.Id });
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SysLog> SysLogs { get; set; }
    }
}
