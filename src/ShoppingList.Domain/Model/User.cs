using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Domain.Model
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Profile Profile { get; set; }
    }
}