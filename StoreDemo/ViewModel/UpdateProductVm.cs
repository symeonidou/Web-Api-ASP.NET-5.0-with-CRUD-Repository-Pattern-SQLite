using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDemo.ViewModel
{
    public class UpdateProductVm
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
    }
}
