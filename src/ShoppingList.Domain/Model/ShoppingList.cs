using System.Collections.Generic;

namespace ShoppingList.Domain.Model
{
    public class ShoppingList : Base
    {
        public ShoppingList()
        {
            Items = new List<Item>();
        }
        public virtual List<Item> Items { get; set; }
    }
}