using ShoppingList.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList.Infrastructure.EntityFramework
{
    public class InitialDataLoadProvider
    {
        public static void InitializeDatabase(ShoppingListContext context)
        {
            if (!context.Set<Supermarket>().Any())
            {
                var supermarket = SaveDefaultSupermaketList(context);
                context.Set<Supermarket>().AddRange(supermarket);
            }

            if (!context.Set<Profile>().Any())
            {
                var profile = SaveDefaultProfile(context);
                context.Set<Profile>().AddRange(profile);
            }

            context.SaveChanges();
        }

        private static List<Supermarket> SaveDefaultSupermaketList(ShoppingListContext context)
        {
            var supermarket = new List<Supermarket>();

            supermarket.Add(new Supermarket
            {
                Name = "Metro",
                Date = DateTime.Now,
            });
            supermarket.Add(new Supermarket
            {
                Name = "Loblaws",
                Date = DateTime.Now,
            });
            supermarket.Add(new Supermarket
            {
                Name = "No Frills",
                Date = DateTime.Now,
            });
            supermarket.Add(new Supermarket
            {
                Name = "Sobeys",
                Date = DateTime.Now,
            });
            supermarket.Add(new Supermarket
            {
                Name = "FreshCo",
                Date = DateTime.Now,
            });
            supermarket.Add(new Supermarket
            {
                Name = "Walmart",
                Date = DateTime.Now,
            });
            supermarket.Add(new Supermarket
            {
                Name = "Pavão",
                Date = DateTime.Now,
            });

            return supermarket;
        }

        private static List<Profile> SaveDefaultProfile(ShoppingListContext context)
        {
            var profile = new List<Profile>();

            profile.Add(new Profile
            {
                Id = 1,
                Name = "Admin",
                Date = DateTime.Now,
            });
            profile.Add(new Profile
            {
                Id = 2,
                Name = "User",
                Date = DateTime.Now,
            });
            profile.Add(new Profile
            {
                Id = 3,
                Name = "Preview",
                Date = DateTime.Now,
            });

            return profile;
        }
    }
}