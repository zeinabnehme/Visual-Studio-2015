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

namespace SearchClientWebApp.Areas.OP.Controllers
{
    public class accountsController : Controller
    {
        private mifosEntitiesConnection db = new mifosEntitiesConnection();

        // GET: accounts
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var accounts = db.accounts.Where(p=> p.CUSTOMER_ID== id).Include(a => a.account_state).Include(a => a.personnel).Include(a => a.office);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(await accounts.ToListAsync());
        }

        // GET: accounts/Details/5
        [Authorize(Roles = "ERP_Search_Loans")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = await db.accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
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
