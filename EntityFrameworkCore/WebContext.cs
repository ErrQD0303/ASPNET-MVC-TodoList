

using Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure
{
    public class WebContext<T> : DbContext where T : WebContext<T>
    {
        IEFDBConnection? _efConnection;

        public WebContext(DbContextOptions<T> options) : base(options) { }

        public WebContext(IEFDBConnection efConnection)
        {
            _efConnection = efConnection;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("TodoItems");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).IsRequired();
                entity.Property(e => e.IsCompleted).IsRequired();
                entity.HasIndex(ti => new { ti.Text }).IsUnique();
            });
        }
    }
}