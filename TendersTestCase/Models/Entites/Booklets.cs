using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TendersTestCase.Models
{
    public class Booklets
    {
        [Key]
        public int BookletID { get; set; }

        public Activity Activity { get; set; }

        public Status Status { get; private set;  } = Status.Available;

        public virtual ICollection<Booklet_Sales> Booklet_Sales { get; set; } = new HashSet<Booklet_Sales>();
    }
}