using StoreDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDemo.ViewModel
{

    //The VM classes is helping to clean up our requests, helps us control what data to create and what data defines the system

    public class CreateProductVm
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }

    }
}
