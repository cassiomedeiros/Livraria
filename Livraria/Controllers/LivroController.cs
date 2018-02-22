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
    public class LivroController : Controller
    {
        private LivrariaContext db = new LivrariaContext();

        // GET: Livro
        public ActionResult Index()
        {
            var livro = db.Livro.Include(l => l.Autor).Include(l => l.Empresa);

            List<Livro> livros = livro.ToList();
            
            foreach(Livro obj in livros)
            {
                obj.Vendas = db.Venda.Where(v => v.LivroId == obj.LivroId).ToList();

                obj.EntradasEstoque = db.EntradaEstoque.Where(e=> e.LivroId == obj.LivroId).ToList();

               if (obj.EntradasEstoque != null)
                {
                    foreach(EntradaEstoque objEntrada in obj.EntradasEstoque)
                    {
                        objEntrada.PerdasEstoque = db.PerdaEstoque.Where(p => p.EntradaEstoqueId == objEntrada.EntradaEstoqueId).ToList();
                    }
                }

            }

            //return View(livro.ToList().OrderBy(l => l.Nome));
            return View(livros.OrderBy(l => l.Nome));
        }

        // GET: Livro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }

            livro.Empresa = db.Empresa.Find(livro.EmpresaId);
            livro.Autor = db.Autor.Find(livro.AutorId);

            return View(livro);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Nome");
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "NomeFantasia");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroId,EmpresaId,Nome,AutorId,AnoPublicao")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Livro.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Nome", livro.AutorId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "NomeFantasia", livro.EmpresaId);
            return View(livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Nome", livro.AutorId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "NomeFantasia", livro.EmpresaId);
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroId,EmpresaId,Nome,AutorId,AnoPublicao")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Nome", livro.AutorId);
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "NomeFantasia", livro.EmpresaId);
            return View(livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livro.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livro.Find(id);
            db.Livro.Remove(livro);
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
