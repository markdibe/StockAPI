using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IImage
    {
        ImageBO Create(ImageBO image);

        ImageBO Delete(string id);

        ImageBO Update(ImageBO image);

        List<ImageBO> Get();

        ImageBO GetById(string Id);

        List<ImageBO> Create_List(List<ImageBO> images);

        List<ImageBO> Delete_List(List<string> Ids);

        List<ImageBO> GetById_List(List<string> Ids);
    }
}
