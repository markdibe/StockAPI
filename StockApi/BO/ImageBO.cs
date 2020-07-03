using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class ImageBO
    {
        public string Id { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(250)]
        [MinLength(4)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
