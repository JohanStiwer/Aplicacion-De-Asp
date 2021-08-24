using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_de_asp.Models;

namespace Aplicacion_de_asp.Controllers
{
    public class ProductoImagenController : Controller
    {
        // GET: ProductoImagen
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                 return View(db.producto_imagen.ToList());
            }
        }
        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }

        }
        public ActionResult ListaProductos()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_imagen productoImagen)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_imagen.Add(productoImagen);
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
                var findproductoImagen = db.producto_imagen.Find(id);
                return View(findproductoImagen);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findproductoImagen = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(findproductoImagen);
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
                    producto_imagen findproductoImagen = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                    return View(findproductoImagen);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen EditproductoImagen)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_imagen productoImagen = db.producto_imagen.Find(EditproductoImagen.id);
                    productoImagen = db.producto_imagen.Find(EditproductoImagen.imagen);
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