using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Parameters
{
    public class CategoryParameter : QueryParameter
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
