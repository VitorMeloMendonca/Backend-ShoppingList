using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Domain.Model
{
    public class Tax : Base
    {
        public string Name { get; set; }
        public decimal Fee { get; set; }
    }
}