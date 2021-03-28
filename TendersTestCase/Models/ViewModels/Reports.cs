using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TendersTestCase.Models
{
    public class Report
    {
     
        [Display(Name ="Date of Transaction")]
        [DataType(DataType.Date)]

        public DateTime? Date { get; set; }

       
        public int BookletID { get; set; }

       
        public string CustomerID { get; set; }

        public string CustomerName { get; set; }
    }
}