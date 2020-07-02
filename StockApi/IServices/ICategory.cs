using StockApi.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface ICategory
    {
        CategoryBO Create(CategoryBO cat);

        CategoryBO Delete(Int64 id);

        CategoryBO Update(CategoryBO cat);

        CategoryBO GetById(Int64 id);

        List<CategoryBO> Get();

        List<CategoryBO> Create_List(List<CategoryBO> CatList);
        
    }
}
