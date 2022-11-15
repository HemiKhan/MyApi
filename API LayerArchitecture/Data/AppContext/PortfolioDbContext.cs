using Microsoft.EntityFrameworkCore;
using Models.Model.PortfolioModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppContext
{
    public class PortfolioDbContext :DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {

        }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Projects> Projects { get; set; }
    }
}
