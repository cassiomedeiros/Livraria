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
    public class UsuarioEmpresaController : Controller
    {
        private LivrariaContext db = new LivrariaContext();

        // GET: UsuarioEmpresa
        public ActionResult Index()
        {
            var usuarioEmpresas = db.UsuarioEmpresa.Include(u => u.Empresa).Include(u => u.Usuario);
            return View(usuarioEmpresas.ToList());
        }

        // GET: UsuarioEmpresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresa.Find(id);
            if (usuarioEmpresa == null)
            {
                return HttpNotFound();
            }

            usuarioEmpresa.Empresa = db.Empresa.Find(usuarioEmpresa.EmpresaId);
            usuarioEmpresa.Usuario = db.Usuario.Find(usuarioEmpresa.UsuarioId);

            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresa/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "NomeFantasia");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nome");
            return View();
        }

        // POST: UsuarioEmpresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioEmpresaId,UsuarioId,EmpresaId")] UsuarioEmpresa usuarioEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioEmpresa.Add(usuarioEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresa, "EmpresaId", "NomeFantasia", usuarioEmpresa.EmpresaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "Nome", usuarioEmpresa.UsuarioId);
            return View(usuarioEmpresa);
        }

     
        // GET: UsuarioEmpresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresa.Find(id);
            if (usuarioEmpresa == null)
            {
                return HttpNotFound();
            }

            usuarioEmpresa.Empresa = db.Empresa.Find(usuarioEmpresa.EmpresaId);
            usuarioEmpresa.Usuario = db.Usuario.Find(usuarioEmpresa.UsuarioId);

            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresa.Find(id);
            db.UsuarioEmpresa.Remove(usuarioEmpresa);
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
