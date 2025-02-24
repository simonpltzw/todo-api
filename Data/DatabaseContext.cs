using Microsoft.EntityFrameworkCore;
using Todo.API.Models;

namespace Todo.API.Data
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<RoutineDefinition> RoutineDefinitions { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(c =>
            {
                c.HasKey(x => x.Id);

                c.Property(x => x.FederatedAccountId)
                    .HasMaxLength(255)
                    .IsRequired();

                c.Property(x => x.Name)
                    .HasMaxLength(50);

                c.Property(x => x.CreatedAt)
                    .IsRequired();

                c.Property(x => x.Active)
                    .IsRequired();
            });

            modelBuilder.Entity<UserProject>(c =>
            {
                c.HasKey(x => x.Id);

                c.HasOne(x => x.User)
                    .WithMany(x => x.UserProjects)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                c.HasOne(x => x.Project)
                    .WithMany(x => x.UserProjects)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                c.Property(x => x.CreatedAt)
                   .IsRequired();

                c.Property(x => x.Active)
                    .IsRequired();
            });

            modelBuilder.Entity<Project>(c =>
            {
                c.HasKey(x => x.Id);

                c.HasOne(x => x.CreatedBy)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedById)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                c.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                c.Property(x => x.Description);

                c.Property(x => x.CreatedAt)
                   .IsRequired();

                c.Property(x => x.Active)
                    .IsRequired();
            });

            modelBuilder.Entity<Topic>(c =>
            {
                c.HasKey(x => x.Id);

                c.HasOne(x => x.Project)
                    .WithMany(x => x.Topics)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                c.HasOne(x => x.CreatedBy)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedById)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                c.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                c.Property(x => x.IsBaseTopic)
                    .IsRequired();

                c.Property(x => x.CreatedAt)
                   .IsRequired();

                c.Property(x => x.Active)
                    .IsRequired();
            });

            modelBuilder.Entity<Models.Task>(c =>
            {
                c.HasKey(x => x.Id);

                c.HasOne(x => x.Topic)
                    .WithMany(x => x.Tasks)
                    .HasForeignKey(x => x.TopicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                c.HasOne(x => x.RoutineDefinition)
                    .WithOne()
                    .HasForeignKey<Models.Task>(x => x.RoutineDefinitionId)
                    .OnDelete(DeleteBehavior.Cascade);

                c.HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId)
                    .OnDelete(DeleteBehavior.Cascade);

                c.Property(x => x.Name)
                    .HasMaxLength(200)
                    .IsRequired();

                c.Property(x => x.Description);

                c.Property(x => x.Planned);

                c.Property(x => x.Deadline);

                c.Property(x => x.Completed)
                    .IsRequired();

                c.Property(x => x.Type);
            });

            modelBuilder.Entity<RoutineDefinition>(c =>
            {
                c.HasKey(x => x.Id);

                c.Property(x => x.Type)
                    .IsRequired();

                c.Property(x => x.Day);

                c.Property(x => x.DaysOfWeek);
            });
        }
    }
}
