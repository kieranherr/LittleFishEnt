using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LittleFishEnt.Models;

namespace LittleFishEnt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LittleFishEnt.Models.Bios> Bios { get; set; }
        public DbSet<LittleFishEnt.Models.Images> Images { get; set; }
    }
}
