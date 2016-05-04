using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SearchClientWebApp;
using SearchClientWebApp.Models;
using System.Web.Services;
using System.Web.Script.Services;
using System.Threading;

namespace SearchClientWebApp.Areas.OP.Models
{
    public class DataTableController : Controller
    {
        private mifosEntitiesConnection db = new mifosEntitiesConnection();

        // GET: customers
        public async Task<ActionResult> Index(string SearchStr, int pageNumber = 0)
        {
            ViewBag.SearchStr = SearchStr;

            ViewBag.PageNumber = pageNumber;
            const int pageSize = 25;
            List<CustomerBref.GroupSummaryModel> customers = new List<CustomerBref.GroupSummaryModel>();
            if (!String.IsNullOrEmpty(SearchStr))
            {
                List<string> splited = new List<string>(SearchStr.Split(' '));
                customers = await db.customers.Select(p => new CustomerBref.GroupSummaryModel
                {
                    CUSTOMER_ID = p.CUSTOMER_ID,
                    GLOBAL_CUST_NUM = p.GLOBAL_CUST_NUM,
                    DISPLAY_NAME = p.DISPLAY_NAME,
                    GOVERNMENT_ID = p.GOVERNMENT_ID,
                    office = p.office,
                    name = p.FIRST_NAME,                   
                    last = p.LAST_NAME



                })

                      .OrderBy(p => p.DISPLAY_NAME).Skip(pageSize * pageNumber)
                .Take(pageSize).Where(d => d.DISPLAY_NAME.Equals(SearchStr) || (d.name + " " + d.last).Equals(SearchStr) || d.GOVERNMENT_ID.Contains(SearchStr)).ToListAsync();

                //.Where(p => splited.All(r => (r.Contains(p.name)) || (r.Contains(p.middle) ) || (r.Contains(p.last))))
                //               .ToList();


                return View(customers);
            }
            else
            {
                return View(customers);
            }
        }

        // GET: customers/Details/5
        public ActionResult Details(int? id)
        {
            CustomerDetail.SummaryModel customerModel = new CustomerDetail.SummaryModel();
            customer customer = new customer();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            customer = db.customers.Find(id);

            customerModel.DISPLAY_NAME = customer.DISPLAY_NAME;
            customerModel.customer_state = customer.customer_state;
            customerModel.customer_detail = customer.customer_detail;
            customerModel.CUSTOMER_ID = customer.CUSTOMER_ID;
            customerModel.GLOBAL_CUST_NUM = customer.GLOBAL_CUST_NUM;
            customerModel.office = customer.office;
            customerModel.personnel = customer.personnel;
            customerModel.GOVERNMENT_ID = customer.GOVERNMENT_ID;
            customerModel.DATE_OF_BIRTH = customer.DATE_OF_BIRTH;
            customerModel.DISCRIMINATOR = customer.DISCRIMINATOR;
            customerModel.OldMIS = customer.EXTERNAL_ID;
            customerModel.Address = customer.DISPLAY_ADDRESS;

            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Search(string term)
        {
            Suggname sugg = new Suggname();
            return Json(sugg.search(term), JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
