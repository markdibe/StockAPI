using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class StoreBO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int? ItemsQuantity { get; set; }

        [DataType(DataType.Text)]
        public string Address { get; set; }

        public string City { get; set; }

        public string Road { get; set; }

        public string CoordinationX { get; set; }

        public string CoordinationY { get; set; }


        public string Street { get; set; }

        public virtual ICollection<LocationBO> Locations { get; set; }
    }
}
