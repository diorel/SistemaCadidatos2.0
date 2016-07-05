using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CandidatosSistema.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Realizar el llamado de la vista que contiene la GUI de Autenticación de la aplicación
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult logIn()
        {
            return View();
        }


        ///// <summary>
        ///// Verificar los datos suministrados por el usuario al realizar la petición Post de envió de información
        ///// mediante la GUI de Autenticación de la aplicación.
        ///// </summary>
        ///// <param name=”user”></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult logIn(Models.UserModel user)
        //{
        //    if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
        //    {
        //        if (IsValid(user.Usuario1, user.Clave))//Verificar que el email y clave exista utilizando el método privado
        //        {

        //            FormsAuthentication.SetAuthCookie(user.Usuario1, false); //crea variable de usuario con el usuario
        //            return RedirectToAction(“Index”, “Home”); //dirigir al controlador home vista Index una vez se a autenticado en el sistema
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(“”, “Login data in incorrect”); //adicionar mensaje de error al model
        //        }
        //    }
        //    return View(user);
        //}

        /// <summary>
        /// Realizar el llamado de la vista que contiene la GUI, para registrarse en el sistema
        /// </summary>
        /// <returns></returns>
        public ActionResult Registration()
        {
            return View();
        }






        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
