using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class TitleBO
    {
        public int TitleId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }
    }
}
