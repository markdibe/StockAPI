using StockApi.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IStore
    {
        StoreBO Create(StoreBO store);

        StoreBO Delete(int id);

        StoreBO Update(StoreBO editedStore);
        StoreBO GetById(int id);

        List<StoreBO> Get();

        List<StoreBO> GetById_List(List<int> Ids);

        List<StoreBO> Create_List(List<StoreBO> Stores);

        List<StoreBO> Delete_List(List<StoreBO> Stores);

    }
}
