using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoCEEM.Models;

namespace ProjetoCEEM.Controllers
{
    public class PontoMedidasController : Controller
    {
        private Context db = new Context();

        // GET: PontoMedidas
        public ActionResult Index()
        {
            var pontoMedidas = db.PontoMedidas.Include(p => p.Equipamento);
            return View(pontoMedidas.ToList());
        }

        // GET: PontoMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PontoMedida pontoMedida = db.PontoMedidas.Find(id);
            if (pontoMedida == null)
            {
                return HttpNotFound();
            }
            return View(pontoMedida);
        }

        // GET: PontoMedidas/Create
        public ActionResult Create()
        {
            ViewBag.EquipamentoId = new SelectList(db.Equipamentoes, "Id", "Id");
            return View();
        }

        // POST: PontoMedidas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataMedida,MedidaCorrente,MedidaTensao,EquipamentoId")] PontoMedida pontoMedida)
        {
            pontoMedida.Equipamento = db.Equipamentoes.Find(pontoMedida.EquipamentoId);
            if (!pontoMedida.Equipamento.PodeCadastrarPontos(db))
                ViewBag.NaoPode = @"O equipamento possui o numero máximo de pontos de medida cadastrados";
            if (ModelState.IsValid&&pontoMedida.Equipamento.PodeCadastrarPontos(db))
            {
                db.PontoMedidas.Add(pontoMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipamentoId = new SelectList(db.Equipamentoes, "Id", "Id", pontoMedida.EquipamentoId);
            return View(pontoMedida);
        }

        // GET: PontoMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PontoMedida pontoMedida = db.PontoMedidas.Find(id);
            if (pontoMedida == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipamentoId = new SelectList(db.Equipamentoes, "Id", "Id", pontoMedida.EquipamentoId);
            return View(pontoMedida);
        }

        // POST: PontoMedidas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataMedida,MedidaCorrente,MedidaTensao,EquipamentoId")] PontoMedida pontoMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pontoMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipamentoId = new SelectList(db.Equipamentoes, "Id", "Id", pontoMedida.EquipamentoId);
            return View(pontoMedida);
        }

        // GET: PontoMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PontoMedida pontoMedida = db.PontoMedidas.Find(id);
            if (pontoMedida == null)
            {
                return HttpNotFound();
            }
            return View(pontoMedida);
        }

        // POST: PontoMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PontoMedida pontoMedida = db.PontoMedidas.Find(id);
            db.PontoMedidas.Remove(pontoMedida);
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
