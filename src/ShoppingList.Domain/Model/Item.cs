using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Domain.Model
{
    public class Item : Base
    {
        public int Amount { get; set; }
        public string Observation { get; set; }
        public decimal Price { get; set; }

        public virtual ItemProduct ItemProduct { get; set; }
    }
}