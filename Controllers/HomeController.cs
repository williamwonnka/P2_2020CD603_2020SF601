using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020CD603_2020SF601.Models;
using System.Diagnostics;

namespace P2_2020CD603_2020SF601.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly parcialDbContext _parcialDbContext;



        public HomeController(parcialDbContext parcialDbContext)
        {
            _parcialDbContext = parcialDbContext;
        }

        public IActionResult Index()
        {

            //  var listDepartamentos = (from m in _parcialDbContext.departamentos select m).ToList();
            //  ViewData["listadoDeDepartamentos"] = new SelectList(listDepartamentos, "idDepartameno", "departamento");

            var listDepartamentos = _parcialDbContext.departamentos.ToList();
            ViewData["listadoDeDepartamentos"] = new SelectList(listDepartamentos, "idDepartamento", "departamento");


            //var listGenero = (from m in _parcialDbContext.Generos select m).ToList();
            var listGenero = _parcialDbContext.Generos.ToList();
            ViewData["listadoDeGenneros"] = new SelectList(listGenero, "idGenero", "genero");


            var casosReportados = (from m in _parcialDbContext.CasosReportados
                                   join gen in _parcialDbContext.Generos on m.genero equals gen.idGenero
                                   join dep in _parcialDbContext.departamentos on m.departamento equals dep.idDepartamento
                                   select new
                                   {
                                     departamento = dep.departamento,
                                     genero = gen.genero,
                                     casosConfirmados = m.casosConfirmados,
                                     casosRecuperados = m.numeroRecuperados,
                                     casosFallecidos = m.numeroFallecidos
                                   }).ToList();

            ViewData["casosReportados"] = casosReportados;

            return View();

          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult GuardarRegistro(CasosReportados nuevoCaso)
        {

            _parcialDbContext.Add(nuevoCaso);
            _parcialDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}