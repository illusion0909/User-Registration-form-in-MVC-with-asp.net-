using DotNet_Project9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DotNet_Project9.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("cnstr")
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}