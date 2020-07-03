using Microsoft.EntityFrameworkCore;
using StockApi.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IHolderImage
    {
        HolderImagesBO GetById(string Id);

        HolderImagesBO Create(HolderImagesBO holder);

        HolderImagesBO Update(HolderImagesBO holder);

        HolderImagesBO Delete(string id);

        List<HolderImagesBO> Create_List(List<HolderImagesBO> holderImages);

        List<HolderImagesBO> Delete_List(List<HolderImagesBO> holderImages);

        List<HolderImagesBO> GetById_List(List<string> Ids);

    }
}
