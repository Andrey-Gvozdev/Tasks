using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;

namespace Tasks.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
