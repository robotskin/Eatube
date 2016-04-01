using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderInfoesController : Controller
    {
        private ClientInfoContext db = new ClientInfoContext();

        // GET: OrderInfoes
        public ActionResult Index()
        {
            return View(db.OrderInfoes.ToList());
        }

        // GET: OrderInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.OrderInfoes.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // GET: OrderInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderID,clientID,orderDate")] OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.OrderInfoes.Add(orderInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderInfo);
        }

        // GET: OrderInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.OrderInfoes.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: OrderInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderID,clientID,orderDate")] OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderInfo);
        }

        // GET: OrderInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.OrderInfoes.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: OrderInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderInfo orderInfo = db.OrderInfoes.Find(id);
            db.OrderInfoes.Remove(orderInfo);
            db.SaveChanges();
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
