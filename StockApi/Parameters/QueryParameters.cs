using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Parameters
{
    public class QueryParameters
    {
        private int _size = 5;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private int _page = 1;
        public int Page
        {
            get { return _page; }
            set { _page = value; }
        }

        private string _orderBy = "asc";
        public string OrdeyBy
        {
            get { return _orderBy; }
            set
            {
                if (this.OrdeyBy == "asc" || this.OrdeyBy == "desc")
                {
                    _orderBy = value;
                }
            }
        }
    }
}