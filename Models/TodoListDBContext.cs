using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace denemeShop.Models
{
    public partial class TodoListDBContext : DbContext
    {
        public TodoListDBContext()
        {
        }

        public TodoListDBContext(DbContextOptions<TodoListDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDoListTable> ToDoListTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-BFIQFNI\\SQLEXPRESS;Database=TodoListDB;uid=sa;pwd=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<ToDoListTable>(entity =>
            {
                entity.HasKey(e => e.TaskId).HasName("PK_ToDoListTable");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.TaskContent).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
