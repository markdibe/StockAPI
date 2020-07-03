using StockApi.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockApi.Entities
{
    public class HolderImages
    {
        private string _Id;
        [Key]
        public string Id
        {
            get { return _Id; }
            set { _Id = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToString(); }
        }
        
        [ForeignKey(nameof(HolderInformation))]
        public Int64 HolderId { get; set; }
        public HolderInformationBO HolderInformation { get; set; }

        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }
        public ImageBO Image { get; set; }
    }
}
