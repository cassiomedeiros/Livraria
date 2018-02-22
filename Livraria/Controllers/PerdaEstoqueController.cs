using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Livraria.Data;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class PerdaEstoqueController : Controller
    {
        private LivrariaContext db = new LivrariaContext();

        // GET: PerdaEstoque
        public ActionResult Index()
        {
            var perdaEstoque = db.PerdaEstoque.Include(p => p.EntradaEstoque);
            return View(perdaEstoque.ToList());
        }

        // GET: PerdaEstoque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerdaEstoque perdaEstoque = db.PerdaEstoque.Find(id);
            if (perdaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(perdaEstoque);
        }

        // GET: PerdaEstoque/Create
        public ActionResult Create()
        {
            ViewBag.EntradaEstoqueId = new SelectList(db.EntradaEstoque, "EntradaEstoqueId", "NotaFiscal");
            return View();
        }

        // POST: PerdaEstoque/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerdaEstoqueId,EntradaEstoqueId,Data,Quantidade")] PerdaEstoque perdaEstoque)
        {
            if (ModelState.IsValid)
            {
                db.PerdaEstoque.Add(perdaEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntradaEstoqueId = new SelectList(db.EntradaEstoque, "EntradaEstoqueId", "NotaFiscal", perdaEstoque.EntradaEstoqueId);
            return View(perdaEstoque);
        }

        // GET: PerdaEstoque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerdaEstoque perdaEstoque = db.PerdaEstoque.Find(id);
            if (perdaEstoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntradaEstoqueId = new SelectList(db.EntradaEstoque, "EntradaEstoqueId", "NotaFiscal", perdaEstoque.EntradaEstoqueId);
            return View(perdaEstoque);
        }

        // POST: PerdaEstoque/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerdaEstoqueId,EntradaEstoqueId,Data,Quantidade")] PerdaEstoque perdaEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perdaEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntradaEstoqueId = new SelectList(db.EntradaEstoque, "EntradaEstoqueId", "NotaFiscal", perdaEstoque.EntradaEstoqueId);
            return View(perdaEstoque);
        }

        // GET: PerdaEstoque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerdaEstoque perdaEstoque = db.PerdaEstoque.Find(id);
            if (perdaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(perdaEstoque);
        }

        // POST: PerdaEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerdaEstoque perdaEstoque = db.PerdaEstoque.Find(id);
            db.PerdaEstoque.Remove(perdaEstoque);
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
