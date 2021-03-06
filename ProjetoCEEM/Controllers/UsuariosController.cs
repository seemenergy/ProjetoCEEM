﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ProjetoCEEM.Models;
using ProjetoCEEM.ViewModels;

namespace ProjetoCEEM.Controllers
{
    public class UsuariosController : Controller
    {
        private Context db = new Context();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Login,Senha")] UsuarioLogin usuarioLogin)
        {
            if (db.Usuarios.Count(u => u.Login.Equals(usuarioLogin.Login)) > 0)
            {
                if (db.Usuarios.Single(u => u.Login.Equals(usuarioLogin.Login)).Senha.Equals(usuarioLogin.Senha))
                    ViewBag.Logado = String.Concat(usuarioLogin.Login, @" - Usuario Logado");
                else
                    ModelState.AddModelError("Senha", @"Senha incorreta");
            }
            else
            {
                ModelState.AddModelError("Login",@"Não foi encontrada uma conta com o usuario informado");
            }
            return View(usuarioLogin);
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Login,Email,Senha,Status,DataCadastro,DataInativacao,DataInicioBloqueio,DataFimBloqueio")] Usuario usuario)
        {
            if (!usuario.EmailDisponivel(db))
                ModelState.AddModelError("Email", @"Este email já está sendo usado");

            if (!usuario.LoginDisponivel(db))
                ModelState.AddModelError("Login", @"Este Login já está sendo usado");

            if (ModelState.IsValid && usuario.EmailDisponivel(db) && usuario.LoginDisponivel(db))
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Login,Email,Senha,Status,DataCadastro,DataInativacao,DataInicioBloqueio,DataFimBloqueio")] Usuario usuario)
        {
            if (!usuario.EmailDisponivel(db))
                ModelState.AddModelError("Email", @"Este email já está sendo usado");

            if (!usuario.LoginDisponivel(db))
                ModelState.AddModelError("Login", @"Este Login já está sendo usado");

            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
