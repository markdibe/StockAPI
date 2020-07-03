using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class HolderImagesBO
    {

        public string Id { get; set; }
        
        public Int64 HolderId { get; set; }
        public HolderInformation HolderInformation { get; set; }

        
        public string ImageId { get; set; }
        public Image Image { get; set; }

    }
}
