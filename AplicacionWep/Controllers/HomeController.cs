using AplicacionWep.Models;
using AplicacionWep.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Proyect_Crud.BLL.Services;
using Proyect_Crud.Models;
using System.Diagnostics;
using System.Globalization;

namespace AplicacionWep.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContacServices _ContactServices;
      

        public HomeController(IContacServices contacServices)
        {
           
            this._ContactServices = contacServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Listar()
        {
            IQueryable<Contacto> queryContactSql = await _ContactServices.ObtenerTodos();
            List<ViewModelContact> lista = queryContactSql.Select(
                 z => new ViewModelContact()
                 {
                     IdContacto = z.IdContacto,
                     Nombre = z.Nombre,
                     Telefono = z.Telefono,
                     CorreoElectronico = z.CorreoElectronico,
                     FechaNacimiento = z.FechaNacimiento.Value.ToString("dd/MM/yyyy")

                 }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]

        public async Task<IActionResult> Insertar([FromBody] ViewModelContact contact)
        {
            Contacto NuevoContacto = new Contacto()
            {
                Nombre = contact.Nombre,
                Telefono = contact.Telefono,
                CorreoElectronico = contact.CorreoElectronico,
                FechaNacimiento = DateTime.ParseExact(contact.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CR"))
            };

            bool respuestas = await _ContactServices.Insertar(NuevoContacto);

            return StatusCode(StatusCodes.Status200OK, new {valor = respuestas});
        }

        [HttpPut]

        public async Task<IActionResult> Actualizar([FromBody] ViewModelContact contact)
        {
            Contacto NuevoContacto = new Contacto()
            {
                IdContacto = contact.IdContacto,
                Nombre = contact.Nombre,
                Telefono = contact.Telefono,
                CorreoElectronico = contact.CorreoElectronico,
                FechaNacimiento = DateTime.ParseExact(contact.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CR"))
            };

            bool respuestas = await _ContactServices.Actualizar(NuevoContacto);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuestas });
        }

        [HttpDelete]

        public async Task<IActionResult> Eliminar(int id)
        {
           
            bool respuestas = await _ContactServices.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuestas });
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
    }
}