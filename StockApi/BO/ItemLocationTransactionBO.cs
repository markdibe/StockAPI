using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class ItemLocationTransactionBO
    {


        public string Id { get; set; }

        public string ItemId { get; set; }
        
        public Int64 LocationId { get; set; }

        public ItemBO Item { get; set; }
        public LocationBO Location { get; set; }

        private DateTime _date;
        public DateTime DateOfTransaction { get { return _date; } set { _date = DateTime.Now; } }
    }
}
