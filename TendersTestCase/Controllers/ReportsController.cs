using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TendersTestCase.Models.Context;
using TendersTestCase.Models; 

namespace TendersTestCase.Controllers
{
    public class ReportsController : Controller
    {
        private BookletContext db = new BookletContext();

        // GET: Reports
        public ActionResult Index()
        {
            List<Report> reports = new List<Report>();
            foreach (var item in db.Booklet_Sales.OrderBy(i=>i.Date))
            {
                reports.Add(new Report 
                {
                    Date = item.Date ,
                    BookletID = item.BookletID , 
                    CustomerID = item.CustomerID ,
                    CustomerName = item.CustomerName 
                }
                ); 
            }
            
          
            return View(reports);
        }

    }
}
