using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StockApi.IServices
{
    public interface IGenericFactor<T> where T :class
    {
        T Get();

        T GetById(T value);

        T Create(T value);

        T Create_List( ref List<T> value);


    }
}
