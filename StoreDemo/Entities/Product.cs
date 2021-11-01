using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDemo.Entities
{
    public class Product
        {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        }
}
