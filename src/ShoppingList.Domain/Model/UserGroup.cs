using System.Collections.Generic;

namespace ShoppingList.Domain.Model
{
    public class UserGroup : Base
    {
        public UserGroup()
        {
            Users = new List<User>();
            ShoppingLists = new List<ShoppingList>();
            Purchases = new List<Purchase>();
        }

        public string Name { get; set; }

        public virtual List<Purchase> Purchases { get; set; }
        public virtual List<ShoppingList> ShoppingLists { get; set; }
        public virtual List<User> Users { get; set; }

    }
}