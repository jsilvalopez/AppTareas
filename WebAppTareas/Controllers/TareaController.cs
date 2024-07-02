using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTareas.Datos;
using WebAppTareas.Models;

namespace WebAppTareas.Controllers
{
    public class TareaController : Controller
    {

        TareaDatos _TareaDatos = new TareaDatos();

        // GET: TareaController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            var oLista = _TareaDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(TareaModel oTarea)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _TareaDatos.Guardar(oTarea);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdTarea)
        {
            var oTarea = _TareaDatos.Obtener(IdTarea);
            return View(oTarea);
        }

        [HttpPost]
        public IActionResult Editar(TareaModel oTarea)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _TareaDatos.Editar(oTarea);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int IdTarea)
        {
            var oTarea = _TareaDatos.Obtener(IdTarea);
            return View(oTarea);
        }

        [HttpPost]
        public IActionResult Eliminar(TareaModel oTarea)
        {

            var respuesta = _TareaDatos.Eliminar(oTarea.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }




    }
}
