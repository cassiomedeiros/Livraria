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
    public class EntradaEstoqueController : Controller
    {
        private LivrariaContext db = new LivrariaContext();

        // GET: EntradaEstoque
        public ActionResult Index()
        {
            var entradaEstoque = db.EntradaEstoque.Include(e => e.Fornecedor).Include(e => e.Livro);
            return View(entradaEstoque.ToList());
        }

        // GET: EntradaEstoque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaEstoque entradaEstoque = db.EntradaEstoque.Find(id);
            if (entradaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "FornecedorId", "CNPJCPF");
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "Nome");
            return View();
        }

        // POST: EntradaEstoque/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntradaEstoqueId,LivroId,FornecedorId,Data,NotaFiscal,Quantidade,ValorUnitario")] EntradaEstoque entradaEstoque)
        {
            if (ModelState.IsValid)
            {
                db.EntradaEstoque.Add(entradaEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "FornecedorId", "CNPJCPF", entradaEstoque.FornecedorId);
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "Nome", entradaEstoque.LivroId);
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaEstoque entradaEstoque = db.EntradaEstoque.Find(id);
            if (entradaEstoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "FornecedorId", "CNPJCPF", entradaEstoque.FornecedorId);
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "Nome", entradaEstoque.LivroId);
            return View(entradaEstoque);
        }

        // POST: EntradaEstoque/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntradaEstoqueId,LivroId,FornecedorId,Data,NotaFiscal,Quantidade,ValorUnitario")] EntradaEstoque entradaEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "FornecedorId", "CNPJCPF", entradaEstoque.FornecedorId);
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "Nome", entradaEstoque.LivroId);
            return View(entradaEstoque);
        }

        // GET: EntradaEstoque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaEstoque entradaEstoque = db.EntradaEstoque.Find(id);
            if (entradaEstoque == null)
            {
                return HttpNotFound();
            }
            return View(entradaEstoque);
        }

        // POST: EntradaEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntradaEstoque entradaEstoque = db.EntradaEstoque.Find(id);
            db.EntradaEstoque.Remove(entradaEstoque);
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
