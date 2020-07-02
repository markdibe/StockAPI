using Microsoft.EntityFrameworkCore;
using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IAuthentication
    {
        ICollection<UserBO> Create(ICollection<UserBO> user);

        ICollection<UserBO> Delete(ICollection<string> Ids);

        UserBO GetById(string id);

        ICollection<UserBO> Get();

        UserBO Update(UserBO editedUser);

        bool Login(UserBO userBO);
    }
}
