using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Parameters
{
    public class QueryParameter
    {
        private string _orderBy = "asc";
        public string OrderBy
        {
            get { return _orderBy; }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _orderBy = value;
                }
            }
        }

        private int size = 10;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        private int page = 1;
        public int Page { get { return page; } set { if (value > 0) { page = value; } } }

        
        
    }
}
