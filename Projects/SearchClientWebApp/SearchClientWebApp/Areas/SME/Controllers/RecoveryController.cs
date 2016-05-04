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
using System.Web.Script.Services;
using System.Web.Services;
using SearchClientWebApp.Areas.SME.Models;

namespace SearchClientWebApp.Areas.SME.Controllers
{
    public class RecoveryController : Controller
    {
        private mifosEntitiesConnection db = new mifosEntitiesConnection();

        // GET: Recovery
        public async Task<ActionResult> Index()
        {
            var rec_collection = db.rec_collection.Include(r => r.account).Include(r => r.rec_lookupvalue).Include(r => r.rec_lookupvalue1).Include(r => r.rec_lookupvalue2).Select(p => new CustomRec
            {

                Account_id = p.Account_id,
                CollOrLegal = p.CollOrLegal,
                Type = p.Type,
                DateOfTransfer = p.DateOfTransfer,
                amount = p.amount,
                TypeFollowup = p.TypeFollowup,
                rec_lookupvalue = p.rec_lookupvalue,
                rec_lookupvalue1 = p.rec_lookupvalue1,
                rec_lookupvalue2 = p.rec_lookupvalue2,
              
                
            });
            
            return View(await rec_collection.ToListAsync());
        }

        // GET: Recovery/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rec_collection rec_collection = await db.rec_collection.FindAsync(id);
            if (rec_collection == null)
            {
                return HttpNotFound();
            }
            return View(rec_collection);
        }

        // GET: Recovery/Create
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public ActionResult FillCity(int state)
        {
            IQueryable<State> cities;
            if (state == 9)
            {
                 cities = db.rec_lookupvalue.Where(p => p.EntityId == 1).ToList().Select(item => new State
                 {
                     ID = item.LookupValueId,
                     StateName = item.lookupValueName
                 }).AsQueryable(); 
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
           cities = db.rec_lookupvalue.Where(p => p.EntityId == 3).ToList().Select(item => new State
            {
                ID = item.LookupValueId,
                StateName = item.lookupValueName
            }).AsQueryable(); ;
                  return Json(cities, JsonRequestBehavior.AllowGet);
        }


        
        public ActionResult FillCity2(int state)
        {
            IQueryable<State> cities;
            if (state == 9)
            {
                cities = db.rec_lookupvalue.Where(p => p.EntityId == 2).ToList().Select(item => new State
                {
                    ID = item.LookupValueId,
                    StateName = item.lookupValueName
                }).AsQueryable();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            cities = db.rec_lookupvalue.Where(p => p.EntityId == 4).ToList().Select(item => new State
            {
                ID = item.LookupValueId,
                StateName = item.lookupValueName
            }).AsQueryable(); ;
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(int? id)
        {
            ViewBag.Account_id = id;
            ViewBag.CollOrLegal = new SelectList(db.rec_lookupvalue.Where(p => p.EntityId == 5), "LookupValueId", "lookupValueName");
            //ViewBag.TypeFollowup = new SelectList(db.rec_lookupvalue.Where(p => p.EntityId == 2), "LookupValueId", "lookupValueName");
            //ViewBag.TypeFollowup1 = new SelectList(db.rec_lookupvalue.Where(p => p.EntityId == 4), "LookupValueId", "lookupValueName");
            //ViewBag.Type = new SelectList(db.rec_lookupvalue.Where(p => p.EntityId == 1), "LookupValueId", "lookupValueName");
            //ViewBag.Type1 = new SelectList(db.rec_lookupvalue.Where(p => p.EntityId == 3), "LookupValueId", "lookupValueName");

            return View();
        }

        // POST: Recovery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int? id, [Bind(Include = "Account_id,CollOrLegal,Type,DateOfTransfer,amount,TypeFollowup")] rec_collection rec_collection)
        {
            if (ModelState.IsValid)
            {
                db.rec_collection.Add(rec_collection);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Account_id = id;
            ViewBag.CollOrLegal = new SelectList(db.rec_lookupvalue.Where(p => p.LookupValueId == 5), "LookupValueId", "lookupValueName");
            //ViewBag.TypeFollowup = new SelectList(db.rec_lookupvalue.Where(p => p.LookupValueId == 2), "LookupValueId", "lookupValueName");
            //ViewBag.TypeFollowup1 = new SelectList(db.rec_lookupvalue.Where(p => p.LookupValueId == 4), "LookupValueId", "lookupValueName");
            //ViewBag.Type = new SelectList(db.rec_lookupvalue.Where(p => p.LookupValueId == 1), "LookupValueId", "lookupValueName");
            //ViewBag.Type1 = new SelectList(db.rec_lookupvalue.Where(p => p.LookupValueId == 3), "LookupValueId", "lookupValueName");
            return View(rec_collection);
        }

        // GET: Recovery/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rec_collection rec_collection = await db.rec_collection.FindAsync(id);
            if (rec_collection == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account_id = new SelectList(db.accounts, "ACCOUNT_ID", "GLOBAL_ACCOUNT_NUM", rec_collection.Account_id);
            ViewBag.CollOrLegal = new SelectList(db.rec_lookupvalue, "LookupValueId", "lookupValueName", rec_collection.CollOrLegal);
            ViewBag.TypeFollowup = new SelectList(db.rec_lookupvalue, "LookupValueId", "lookupValueName", rec_collection.TypeFollowup);
            ViewBag.Type = new SelectList(db.rec_lookupvalue, "LookupValueId", "lookupValueName", rec_collection.Type);
            return View(rec_collection);
        }

        // POST: Recovery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Account_id,CollOrLegal,Type,DateOfTransfer,amount,TypeFollowup")] rec_collection rec_collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rec_collection).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Account_id = new SelectList(db.accounts, "ACCOUNT_ID", "GLOBAL_ACCOUNT_NUM", rec_collection.Account_id);
            ViewBag.CollOrLegal = new SelectList(db.rec_lookupvalue, "LookupValueId", "lookupValueName", rec_collection.CollOrLegal);
            ViewBag.TypeFollowup = new SelectList(db.rec_lookupvalue, "LookupValueId", "lookupValueName", rec_collection.TypeFollowup);
            ViewBag.Type = new SelectList(db.rec_lookupvalue, "LookupValueId", "lookupValueName", rec_collection.Type);
            return View(rec_collection);
        }

        // GET: Recovery/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rec_collection rec_collection = await db.rec_collection.FindAsync(id);
            if (rec_collection == null)
            {
                return HttpNotFound();
            }
            return View(rec_collection);
        }

        // POST: Recovery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            rec_collection rec_collection = await db.rec_collection.FindAsync(id);
            db.rec_collection.Remove(rec_collection);
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
