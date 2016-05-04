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
using SearchClientWebApp.Areas.SME.Models;

namespace SearchClientWebApp.Areas.SME.Controllers
{
    public class paymentController : Controller
    {
        private mifosEntitiesConnection db = new mifosEntitiesConnection();

        // GET: payment
        public async Task<ActionResult> Index()
        {
            var rec_payment = db.rec_payment.Include(r => r.account);

            return View(await rec_payment.ToListAsync());
        }

        // GET: payment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rec_payment rec_payment = await db.rec_payment.FindAsync(id);
            if (rec_payment == null)
            {
                return HttpNotFound();
            }
            return View(rec_payment);
        }

        // GET: payment/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Account_id = id;
            payment payment = new payment();
            payment.AccountID = id ?? default(int);
            ViewBag.Due = payment.PaymentAmount;
            ViewBag.TotalPaid = payment.totalpaid;

            return View(payment);
        }

        // POST: payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PaymentID,AccountID,PaymentAmount")] rec_payment rec_payment)
        {
            if (ModelState.IsValid)
            {
                db.rec_payment.Add(rec_payment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Recovery");
            }

            ViewBag.AccountID = new SelectList(db.accounts, "ACCOUNT_ID", "GLOBAL_ACCOUNT_NUM", rec_payment.AccountID);
            return View(rec_payment);
        }

        // GET: payment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rec_payment rec_payment = await db.rec_payment.FindAsync(id);
            if (rec_payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.accounts, "ACCOUNT_ID", "GLOBAL_ACCOUNT_NUM", rec_payment.AccountID);
            return View(rec_payment);
        }

        // POST: payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PaymentID,AccountID,PaymentAmount")] rec_payment rec_payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rec_payment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.accounts, "ACCOUNT_ID", "GLOBAL_ACCOUNT_NUM", rec_payment.AccountID);
            return View(rec_payment);
        }

        // GET: payment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rec_payment rec_payment = await db.rec_payment.FindAsync(id);
            if (rec_payment == null)
            {
                return HttpNotFound();
            }
            return View(rec_payment);
        }

        // POST: payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            rec_payment rec_payment = await db.rec_payment.FindAsync(id);
            db.rec_payment.Remove(rec_payment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
