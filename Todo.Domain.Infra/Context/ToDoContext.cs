using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().ToTable("ToDo");
            modelBuilder.Entity<ToDoItem>().Property(x => x.Id);
            modelBuilder.Entity<ToDoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<ToDoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<ToDoItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<ToDoItem>().Property(x => x.Date);
            modelBuilder.Entity<ToDoItem>().HasIndex(b => b.User);
        }
    }
}