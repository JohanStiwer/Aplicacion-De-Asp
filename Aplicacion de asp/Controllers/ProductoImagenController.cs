using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Aplicacion_de_asp.Models;



namespace Aplicacion_de_asp.Controllers
{
    public class ProductoImagenController : Controller
    {
        [Authorize]

        // GET: ProductoImagen
        public ActionResult Index()
        {
            return View();
        }
        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }
        public ActionResult ListaProducto()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }
        public ActionResult CargarImagen()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CargarImagen(int producto, HttpPostedFile imagen)
        {
            try
            {
                //string para guardar la ruta 
                string filePath = string.Empty;
                string nameFile = "";

                //condicion si llego o no el archivo
                if (imagen != null)
                {
                    //Ruta de la carpeta que guardara el archivo
                    string path = Server.MapPath("~/Uploads/Imagenes");
                    //condicion para saber si la carpeta uploads existe
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //obtener el nombre del archivo 
                    filePath = path + Path.GetFileName(imagen.FileName);

                    //Obtener la extension del archivo
                    string extension = Path.GetExtension(imagen.FileName);

                    //Guardar el archivo
                    imagen.SaveAs(filePath);                                

                }
                using (var db = new inventario2021Entities())
                {
                    var imagenProducto = new producto_imagen();
                    imagenProducto.id_producto = producto;
                    imagenProducto.imagen = "/Uploads/Imagenes/" + nameFile;
                    db.producto_imagen.Add(imagenProducto);
                    db.SaveChanges();
                }
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        
        

    }
}