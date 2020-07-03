using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class ItemLocationTransactionConverter
    {
        private ItemConverter ic;
        private LocationConverter lc;

        public ItemLocationTransactionConverter()
        {
            ic = new ItemConverter();
            lc = new LocationConverter();
        }

        public ItemLocationTransaction Convert(ItemLocationTransactionBO ilt)
        {
            ItemLocationTransaction itemLocationTransaction = new ItemLocationTransaction
            {
                DateOfTransaction = ilt.DateOfTransaction,
                Id = ilt.Id,
                Item = ic.Convert(ilt.Item),
                ItemId = ilt.ItemId,
                Location = lc.Convert(ilt.Location),
                LocationId = ilt.LocationId
            };
            return itemLocationTransaction;
        }

        public ItemLocationTransactionBO Convert(ItemLocationTransaction ilt)
        {
            ItemLocationTransactionBO itemLocationTransaction = new ItemLocationTransactionBO
            {
                DateOfTransaction = ilt.DateOfTransaction,
                Id = ilt.Id,
                Item = ic.Convert(ilt.Item),
                ItemId = ilt.ItemId,
                Location = lc.Convert(ilt.Location),
                LocationId = ilt.LocationId
            };
            return itemLocationTransaction;
        }

        public List<ItemLocationTransaction> Convert(List<ItemLocationTransactionBO> itemLocationTransactions)
        {
            return itemLocationTransactions.Select(x => Convert(x)).ToList();
        }



        public List<ItemLocationTransactionBO> Convert(List<ItemLocationTransaction> itemLocationTransactions)
        {
            return itemLocationTransactions.Select(x => Convert(x)).ToList();
        }
    }
}
