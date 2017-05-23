using Microsoft.Practices.Unity;
using ShoppingList.Domain.Model;
using ShoppingList.Domain.Repository;
using ShoppingList.Infrastructure.EntityFramework;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;

namespace ShoppingList.Service.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext, ShoppingListContext>(new PerResolveLifetimeManager(), new InjectionConstructor("ShoppingListContext"));
            
            container.RegisterType<IRepository<Item>, BaseRepository<Item>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<ItemProduct>, BaseRepository<ItemProduct>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<Product>, BaseRepository<Product>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<Purchase>, BaseRepository<Purchase>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<Domain.Model.ShoppingList>, BaseRepository<Domain.Model.ShoppingList>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<Supermarket>, BaseRepository<Supermarket>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<Tax>, BaseRepository<Tax>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<User>, BaseRepository<User>>(new PerResolveLifetimeManager());
            container.RegisterType<IRepository<UserGroup>, BaseRepository<UserGroup>>(new PerResolveLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}