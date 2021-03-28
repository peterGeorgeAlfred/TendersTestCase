using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TendersTestCase.Models
{
    public class Booklet_Sales
    {
        [Key]
        public int Serial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

         [ForeignKey("Booklets")] 
        public int BookletID { get; set; }

        public virtual Booklets Booklets { get; set; }
        public string CustomerID { get; set; }

        public string CustomerName { get; set; }
    }
}