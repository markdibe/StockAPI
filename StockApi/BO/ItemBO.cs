using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class ItemBO
    {
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        public Int64 CategoryId { get; set; }

        public virtual CategoryBO Category { get; set; }


        public string BarCode { get; set; }
    }
}
