using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Service.WebApi.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}