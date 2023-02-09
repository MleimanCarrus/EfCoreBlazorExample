using System;
using BlazorServerEFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorServerEFCoreDemo.Services
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(configuration.GetConnectionString("DBConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DBConnection")));
            }
        }

        public virtual DbSet<Grade> Grades { get; set; }
		public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
	}
}

