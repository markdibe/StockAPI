using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class ItemImageBO
    {

        public string Id { get; set; }
        
        public string ImageId { get; set; }
        public ImageBO Image { get; set; }

        
        public string ItemId { get; set; }
        public ItemBO Item { get; set; }
    }
}
