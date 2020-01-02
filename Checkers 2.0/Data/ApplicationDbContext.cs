using System;
using System.Collections.Generic;
using System.Text;
using Checkers_2._0.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Checkers_2._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Game> Game { get; set; }
        public DbSet<Player> Player { get; set; }

    }
}
