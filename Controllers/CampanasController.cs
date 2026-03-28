using Microsoft.AspNetCore.Mvc;
using CampanasPortal.Services;

namespace CampanasPortal.Controllers
{
    public class CampanasController : Controller
    {
        // GET /Campanas  →  Listado completo
        public IActionResult Index()
        {
            var campanas = CampanaService.ObtenerTodas();
            return View(campanas);
        }

        // GET /Campanas/Detalle/{id}
        public IActionResult Detalle(int id)
        {
            var campana = CampanaService.ObtenerPorId(id);
            if (campana is null)
                return RedirectToAction(nameof(Index));
            return View(campana);
        }

        // GET /Campanas/Filtro?categoria=Moda&estado=Vigente
        [HttpGet]
        public IActionResult Filtro(string? categoria, string? estado)
        {
            ViewBag.Categorias      = CampanaService.ObtenerCategorias();
            ViewBag.Estados         = CampanaService.ObtenerEstados();
            ViewBag.CategoriaActual = categoria;
            ViewBag.EstadoActual    = estado;

            var resultado = CampanaService.Filtrar(categoria, estado);
            return View(resultado);
        }

        // GET /Campanas/Resumen
        public IActionResult Resumen()
        {
            var resumen = CampanaService.ObtenerResumen();
            return View(resumen);
        }
    }
}
