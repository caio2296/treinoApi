using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TreinoSiteApi.Modulos;
using TreinoSiteApi.Controllers;
using TreinoSiteApi.Repositorios;
using TreinoSiteApi.Services;

namespace TreinoApiView
{
    public class HomeController : Controller
    {
        private readonly IUsuarioClienteRepositorioSql _RepositorioUsuarioCliente;

        public HomeController(IUsuarioClienteRepositorioSql repositorioUsuarioCliente, ITokenService tokenService) 
           
        {

            _RepositorioUsuarioCliente =
                repositorioUsuarioCliente ?? throw new ArgumentNullException(nameof(repositorioUsuarioCliente));

        }


        // GET: HomeController1
        public  ActionResult<string> Autenticar( ModeloUsuarioClienteVerificacaoDto usuario,string returnUrl)
        {

            

            ActionResult<string> a =  returnUrl;
            return a;
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
