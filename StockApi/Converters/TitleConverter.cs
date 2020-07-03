using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class TitleConverter
    {
        public Title Convert(TitleBO t)
        {
            Title title = new Title
            {
                Name = t.Name,
                TitleId = t.TitleId
            };
            return title;
        }

        public TitleBO Convert(Title t)
        {
            TitleBO title = new TitleBO
            {
                Name = t.Name,
                TitleId = t.TitleId
            };
            return title;
        }

        public List<Title> Convert(List<TitleBO> titles)
        {
            return titles.Select(t => Convert(t)).ToList();
        }

        public List<TitleBO> Convert(List<Title> titles)
        {
            return titles.Select(t => Convert(t)).ToList();
        }
    }
}
