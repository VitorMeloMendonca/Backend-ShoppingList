using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Domain.Model
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}