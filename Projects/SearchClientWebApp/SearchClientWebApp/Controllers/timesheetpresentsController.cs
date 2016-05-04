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

namespace SearchClientWebApp.Models
{
    public class timesheetpresentsController : Controller
    {
        private hrEntitiesConnection db = new hrEntitiesConnection();

        // GET: timesheetpresents
        public async Task<ActionResult> Index()
        {
            var timesheetpresents = db.timesheetpresents.Include(t => t.employee).Include(t => t.timesheetyear2016).Include(t => t.timesheetreason);
            return View(await timesheetpresents.ToListAsync());
        }

        // GET: timesheetpresents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timesheetpresent timesheetpresent = await db.timesheetpresents.FindAsync(id);
            if (timesheetpresent == null)
            {
                return HttpNotFound();
            }
            return View(timesheetpresent);
        }

        // GET: timesheetpresents/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.employees, "employee_id", "first_name");
            ViewBag.CalenderID = new SelectList(db.timesheetyear2016, "CalenderID", "DayName");
            ViewBag.Reason = new SelectList(db.timesheetreasons, "ReasonId", "ReasonName");
            return View();
        }

        // POST: timesheetpresents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "attendanceID,employeeID,CalenderID,IsPresent,FromTime,ToTime,Reason,Note,Approved")] timesheetpresent timesheetpresent)
        {
            if (ModelState.IsValid)
            {
                db.timesheetpresents.Add(timesheetpresent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.employees, "employee_id", "first_name", timesheetpresent.employeeID);
            ViewBag.CalenderID = new SelectList(db.timesheetyear2016, "CalenderID", "DayName", timesheetpresent.CalenderID);
            ViewBag.Reason = new SelectList(db.timesheetreasons, "ReasonId", "ReasonName", timesheetpresent.Reason);
            return View(timesheetpresent);
        }

        // GET: timesheetpresents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timesheetpresent timesheetpresent = await db.timesheetpresents.FindAsync(id);
            if (timesheetpresent == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.employees, "employee_id", "first_name", timesheetpresent.employeeID);
            ViewBag.CalenderID = new SelectList(db.timesheetyear2016, "CalenderID", "DayName", timesheetpresent.CalenderID);
            ViewBag.Reason = new SelectList(db.timesheetreasons, "ReasonId", "ReasonName", timesheetpresent.Reason);
            return View(timesheetpresent);
        }

        // POST: timesheetpresents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "attendanceID,employeeID,CalenderID,IsPresent,FromTime,ToTime,Reason,Note,Approved")] timesheetpresent timesheetpresent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timesheetpresent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.employees, "employee_id", "first_name", timesheetpresent.employeeID);
            ViewBag.CalenderID = new SelectList(db.timesheetyear2016, "CalenderID", "DayName", timesheetpresent.CalenderID);
            ViewBag.Reason = new SelectList(db.timesheetreasons, "ReasonId", "ReasonName", timesheetpresent.Reason);
            return View(timesheetpresent);
        }

        // GET: timesheetpresents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timesheetpresent timesheetpresent = await db.timesheetpresents.FindAsync(id);
            if (timesheetpresent == null)
            {
                return HttpNotFound();
            }
            return View(timesheetpresent);
        }

        // POST: timesheetpresents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            timesheetpresent timesheetpresent = await db.timesheetpresents.FindAsync(id);
            db.timesheetpresents.Remove(timesheetpresent);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public ActionResult CreatePerMonth()
        {
            List<timesheetyear2016> test1 = new List<timesheetyear2016>();
            test1 = db.timesheetyear2016.Where(p => p.MonthId == 2).ToList();
            ViewBag.test2 = test1;
            ViewBag.employeeID = new SelectList(db.employees, "employee_id", "first_name");
            ViewBag.CalenderID = new SelectList(db.timesheetyear2016, "CalenderID", "GlobalDate");
            ViewBag.Reason = new SelectList(db.timesheetreasons, "ReasonId", "ReasonName");
            return View();
        }

        // POST: timesheetpresents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePerMonth([Bind(Include = "attendanceID,employeeID,CalenderID,IsPresent,FromTime,ToTime,Reason,Note,Approved")] List<timesheetpresent> timesheetpresents)
        {
           
            foreach (var timesheetpresent in timesheetpresents)
            {
                if (ModelState.IsValid)
                {
                    db.timesheetpresents.Add(timesheetpresent);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");


            }
            return View(timesheetpresents);

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
