using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingList.Infrastructure.EntityFramework
{
    public class ShoppingListDbInitializer : CreateDatabaseIfNotExists<ShoppingListContext>
    {
        public ShoppingListDbInitializer()
        {
        }

        public override void InitializeDatabase(ShoppingListContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(ShoppingListContext context)
        {
            base.Seed(context);
        }
    }
}