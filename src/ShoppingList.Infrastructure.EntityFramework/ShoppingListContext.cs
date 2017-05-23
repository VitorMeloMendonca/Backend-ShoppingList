using ShoppingList.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ShoppingList.Infrastructure.EntityFramework
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext()
        {
        }

        public ShoppingListContext(string connectionStringName) : base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new ShoppingListDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            modelBuilder.Entity<Purchase>().HasMany(a => a.Items).WithOptional();

            modelBuilder.Entity<Item>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<ItemProduct>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Profile>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<Domain.Model.ShoppingList>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            modelBuilder.Entity<Domain.Model.ShoppingList>().HasMany(a => a.Items);

            modelBuilder.Entity<Supermarket>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Tax>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<UserGroup>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            modelBuilder.Entity<UserGroup>().HasMany(p => p.Users);
            modelBuilder.Entity<UserGroup>().HasMany(p => p.Purchases).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<UserGroup>().HasMany(p => p.ShoppingLists).WithOptional().WillCascadeOnDelete(true);
        }
    }
}