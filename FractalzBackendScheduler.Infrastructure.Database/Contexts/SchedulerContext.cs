using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;

namespace FractalzBackendScheduler.Infrastructure.Database.Contexts
{
    public class SchedulerContext : DbContext
    {
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
