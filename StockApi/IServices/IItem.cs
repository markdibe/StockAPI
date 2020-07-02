using StockApi.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IItem
    {
        ItemBO Create(ItemBO item);

        ItemBO Delete(string Id);

        ItemBO Update(ItemBO item);

        ItemBO GetById(string Id);

        List<ItemBO> Get();

        List<ItemBO> Create_List(List<ItemBO> ItemList);

        List<ItemBO> Delete_List(List<ItemBO> ItemList);
    }
}
