namespace ShoppingList.Infrastructure.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShoppingListContext context)
        {
            InitialDataLoadProvider.InitializeDatabase(context);
        }
    }
}
