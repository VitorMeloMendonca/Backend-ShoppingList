using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Domain.Model
{
    public class Purchase : Base
    {
        public Purchase()
        {
            Items = new List<Item>();
        }

        public decimal Total { get; set; }

        public virtual List<Item> Items { get; set; }
        public virtual Supermarket Supermarket { get; set; }
        public virtual Tax Tax { get; set; }
    }
}