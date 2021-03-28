using System;
using System.Data.Entity;
using System.Linq;

namespace TendersTestCase.Models.Context
{
    public class BookletContext : DbContext
    {
        
        public BookletContext()
            : base("name=BookletContext")
        {
        }

      

         public virtual DbSet<Booklets> Booklets { get; set; }
         public virtual DbSet<Booklet_Sales> Booklet_Sales { get; set; }
    }

   
}