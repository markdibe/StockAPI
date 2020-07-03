using StockApi.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IHolderInfo
    {
        HolderInformationBO Create(HolderInformationBO holderInformation);

        HolderInformationBO Update(HolderInformationBO holderInformation);

        HolderInformationBO Delete(long id);

        HolderInformationBO GetById(long id);

        List<HolderInformationBO> Get();

        List<HolderInformationBO> Create_List(List<HolderInformationBO> holderInformationList);

        List<HolderInformationBO> Delete_List(List<long> Ids);

        List<HolderInformationBO> GetById_List(List<long> Ids);

    }
}
