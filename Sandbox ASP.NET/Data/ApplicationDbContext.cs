using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sandbox_ASP.NET.Models;

namespace Sandbox_ASP.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LevelModel> Levels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}