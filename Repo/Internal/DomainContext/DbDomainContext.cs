using Microsoft.EntityFrameworkCore;
using Repo.Internal.Entities;

namespace Repo.Internal.DomainContext
{
    public class DbDomainContext : DbContext
    {
        internal DbSet<Employee> Employees { get; set; } = null!;
        internal DbSet<Job> Jobs { get; set; } = null!;
        internal DbSet<JobTask> JobTasks { get; set; } = null!;

        public DbDomainContext(DbContextOptions<DbDomainContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbConfiguration.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbConfiguration.OnModelCreating(modelBuilder);
        }

        public void SeedTestData()
        {
            if (!Employees.Any() && !Jobs.Any() && !JobTasks.Any())
            {
                var employees = new[]
                {
                    new Employee { Name = "Alice Johnson" },
                    new Employee { Name = "Bob Smith" },
                    new Employee { Name = "Charlie Davis" },
                    new Employee { Name = "Dana White" },
                    new Employee { Name = "Ethan Brown" },
                    new Employee { Name = "Fiona Green" },
                    new Employee { Name = "George Black" }
                };
                Employees.AddRange(employees);
                SaveChanges();

                var jobs = new[]
                {
                    new Job { Name = "Website Redesign", Employees = new[] { employees[0], employees[1], employees[2] } },
                    new Job { Name = "Data Center Overhaul", Employees = new[] { employees[2], employees[3], employees[4] } },
                    new Job { Name = "Mobile App Development", Employees = new[] { employees[0], employees[4], employees[5] } },
                    new Job { Name = "AI Research Project", Employees = new[] { employees[1], employees[5], employees[6] } },
                    new Job { Name = "IT Support Rollout", Employees = new[] { employees[3], employees[4], employees[6] } }
                };
                Jobs.AddRange(jobs);
                SaveChanges();

                var jobTasks = new[]
                {
                    new JobTask { Name = "Design new UI mockups", Job = jobs[0], Employees = new[] { employees[0], employees[1] } },
                    new JobTask { Name = "Implement responsive layout", Job = jobs[0], Employees = new[] { employees[1], employees[2] } },
                    new JobTask { Name = "Upgrade server hardware", Job = jobs[1], Employees = new[] { employees[2], employees[3] } },
                    new JobTask { Name = "Setup new firewall", Job = jobs[1], Employees = new[] { employees[3], employees[4] } },
                    new JobTask { Name = "Build login system", Job = jobs[2], Employees = new[] { employees[0], employees[5] } },
                    new JobTask { Name = "Integrate API backend", Job = jobs[2], Employees = new[] { employees[4], employees[5] } },
                    new JobTask { Name = "Train ML model", Job = jobs[3], Employees = new[] { employees[5], employees[6] } },
                    new JobTask { Name = "Prepare research paper", Job = jobs[3], Employees = new[] { employees[1], employees[6] } },
                    new JobTask { Name = "Deploy remote assistance tool", Job = jobs[4], Employees = new[] { employees[3], employees[4] } },
                    new JobTask { Name = "Onboard new support staff", Job = jobs[4], Employees = new[] { employees[4], employees[6] } }
                };
                JobTasks.AddRange(jobTasks);
                SaveChanges();
            }
        }
    }
}
