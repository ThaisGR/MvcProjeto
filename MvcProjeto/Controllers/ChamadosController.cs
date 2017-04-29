using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcProjeto.Models;

namespace MvcProjeto.Controllers
{
    public class ChamadosController : Controller
    {
        private MvcProjetoContext db = new MvcProjetoContext();

        // GET: Chamados
        public ActionResult Index()
        {
            var chamados = db.Chamados.Include(c => c._Tipo).Include(c => c._Usuario);
            return View(chamados.ToList());
        }

        // GET: Chamados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // GET: Chamados/Create
        public ActionResult Create()
        {

            Tipo t = new Models.Tipo { Nome = "Melhoria" };
            var items = db.Tipoes.Select(x => x.Nome == t.Nome);
            if (items.Count() == 0) { db.Tipoes.Add(t); }

            t = new Models.Tipo { Nome = "Correção" };
            items = db.Tipoes.Select(x => x.Nome == t.Nome);
            if (items.Count() == 0) { db.Tipoes.Add(t); }

            t = new Models.Tipo { Nome = "Tarefa" };
            items = db.Tipoes.Select(x => x.Nome == t.Nome);
            if (items.Count() == 0) { db.Tipoes.Add(t); }
            db.SaveChanges();


            ViewBag.TipoID = new SelectList(db.Tipoes, "TipoID", "Nome");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome");
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChamadoID,Titulo,Descricao,TipoID,UsuarioID")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Chamados.Add(chamado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoID = new SelectList(db.Tipoes, "TipoID", "Nome", chamado.TipoID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", chamado.UsuarioID);
            return View(chamado);
        }

        // GET: Chamados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoID = new SelectList(db.Tipoes, "TipoID", "Nome", chamado.TipoID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", chamado.UsuarioID);
            return View(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChamadoID,Titulo,Descricao,TipoID,UsuarioID")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoID = new SelectList(db.Tipoes, "TipoID", "Nome", chamado.TipoID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", chamado.UsuarioID);
            return View(chamado);
        }

        // GET: Chamados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chamado chamado = db.Chamados.Find(id);
            db.Chamados.Remove(chamado);
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
