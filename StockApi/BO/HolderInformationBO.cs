using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.BO
{
    public class HolderInformationBO
    {
        public Int64 Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string NumberOfRegistration { get; set; }

        public string LocationOfRegistration { get; set; }

        [Required]
        
        public int TitleId { get; set; }
        public virtual TitleBO Title { get; set; }
    }
}
