using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class HolderInformationConverter
    {
        private TitleConverter titleConverter;
        public HolderInformationConverter()
        {
            titleConverter = new TitleConverter();
        }
        public HolderInformation Convert(HolderInformationBO hi)
        {

            HolderInformation holderInformation = new HolderInformation
            {
                DateOfBirth = hi.DateOfBirth,
                FatherName = hi.FatherName,
                FirstName = hi.FirstName,
                Id = hi.Id,
                LastName = hi.LastName,
                LocationOfRegistration = hi.LocationOfRegistration,
                MotherName = hi.MotherName,
                NumberOfRegistration = hi.NumberOfRegistration,
                Title = titleConverter.Convert(hi.Title),
                TitleId = hi.TitleId
            };
            return holderInformation;
        }

        public HolderInformationBO Convert(HolderInformation hi)
        {
            HolderInformationBO holderInformation = new HolderInformationBO
            {
                DateOfBirth = hi.DateOfBirth,
                FatherName = hi.FatherName,
                FirstName = hi.FirstName,
                Id = hi.Id,
                LastName = hi.LastName,
                LocationOfRegistration = hi.LocationOfRegistration,
                MotherName = hi.MotherName,
                NumberOfRegistration = hi.NumberOfRegistration,
                Title = titleConverter.Convert(hi.Title),
                TitleId = hi.TitleId
            };
            return holderInformation;
        }

        public List<HolderInformation> Convert(List<HolderInformationBO> HolderInformationList)
        {
            return HolderInformationList.Select(x => Convert(x)).ToList();
        }

        public List<HolderInformationBO> Convert(List<HolderInformation> HolderInformationList)
        {
            return HolderInformationList.Select(x => Convert(x)).ToList();
        }
    }
}
