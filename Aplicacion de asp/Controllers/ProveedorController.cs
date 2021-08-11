using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_de_asp.Models;

namespace Aplicacion_de_asp.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor       
        public ActionResult Index()

        {
            using (var db = new inventario2021Entities())
            {
                return View(db.proveedor.ToList());
            }


        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var findProveedor = db.proveedor.Find(id);
                return View(findProveedor);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findProveedor = db.proveedor.Find(id);
                    db.proveedor.Remove(findProveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor findProveedor = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findProveedor);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }


        }
        public ActionResult Edit(proveedor EditProveedor)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    
                    proveedor proveedor = db.proveedor.Find(EditProveedor.id);
                    proveedor.nombre = EditProveedor.nombre;
                    proveedor.direccion = EditProveedor.direccion;
                    proveedor.telefono = EditProveedor.telefono;
                    proveedor.nombre_contacto = EditProveedor.nombre_contacto;
                    
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


    }
}