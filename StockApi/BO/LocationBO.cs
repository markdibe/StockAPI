using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class LocationBO
    {
        public Int64 Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(4), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string CoordinationX { get; set; }

        public string CoordinationY { get; set; }

        public Int64? ParentId { get; set; }

        
        public int StoreId { get; set; }
        public StoreBO Store { get; set; }
    }
}
