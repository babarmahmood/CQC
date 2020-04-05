using Microsoft.EntityFrameworkCore;
using QcsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<LightFeedback> LightSurvey { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=SurveyDb;Integrated Security=SSPI;");
        //    }
        //}
    }
}
