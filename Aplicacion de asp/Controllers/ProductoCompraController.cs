using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_de_asp.Models;

namespace Aplicacion_de_asp.Controllers
{
    public class ProductoCompraController : Controller
    {
        // GET: ProductoCompra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_compra.ToList());
            }                
        }
        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }

        }
        public static int NombreCompra(int idCompra)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto_compra.Find(idCompra).id_compra;
            }
        }
        public ActionResult ListaProducto()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }
        public ActionResult ListaCompra()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.compra.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra producto_Compra)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_compra.Add(producto_Compra);
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
                var findProductocompra = db.producto_compra.Find(id);
                return View(findProductocompra);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findProductocompra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(findProductocompra);
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
                    producto_compra findProductocompra = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                    return View(findProductocompra);
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
        public ActionResult Edit(producto_compra Editcompraproducto)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_compra productoImagen = db.producto_compra.Find(Editcompraproducto.id);
                    Editcompraproducto = db.producto_compra.Find(Editcompraproducto.cantidad);                   
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