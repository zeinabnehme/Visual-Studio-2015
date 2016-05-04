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

namespace SearchClientWebApp.Areas.SME.Models
{
    public class RecSearchController : Controller
    {
        private mifosEntitiesConnection db = new mifosEntitiesConnection();

        // GET: customers
        public ActionResult Index(string SearchStr, int pageNumber = 0)

        {
            int[] myInts = {453,454,456,457,458,459,460,461,462,463,464,465,466,467,468,469,470,471,472,473,555,556,598,605,619,635,636};
            ViewBag.SearchStr = SearchStr;
            ViewBag.PageNumber = pageNumber;
            const int pageSize = 25;
            List<CustomerBrefRec.GroupSummaryModel> customers = new List<CustomerBrefRec.GroupSummaryModel>();
            if (!String.IsNullOrEmpty(SearchStr))
            {
                customers = db.customers.Select(p => new CustomerBrefRec.GroupSummaryModel
                {
                    CUSTOMER_ID = p.CUSTOMER_ID,
                    GLOBAL_CUST_NUM = p.GLOBAL_CUST_NUM,
                    DISPLAY_NAME = p.DISPLAY_NAME,
                    //DISPLAY_ADDRESS = p.DISPLAY_ADDRESS,
                    GOVERNMENT_ID = p.GOVERNMENT_ID,

                    //customer_address_detail = p.customer_address_detail,
                    office = p.office,
                    pers = p.personnel,
                     name = p.FIRST_NAME,
                    last = p.LAST_NAME
                    
                })

                      .OrderBy(p => p.DISPLAY_NAME).Skip(pageSize * pageNumber)
                .Take(pageSize)
                .Where(d => (d.DISPLAY_NAME.Equals(SearchStr) || (d.name + " " + d.last).Equals(SearchStr) || d.GOVERNMENT_ID.Contains(SearchStr))
                             /*  || s.GLOBAL_CUST_NUM.Contains(SearchStr)*/ && 
                               (myInts).Contains(d.pers.PERSONNEL_ID) 
                               ) .ToList();


                return View(customers.ToList());
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
