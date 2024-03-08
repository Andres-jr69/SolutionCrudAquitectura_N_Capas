using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AplicacionWeb.Models;
using ProyectoCrud.AplicacionWeb.Models.ViewModels;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using System.Diagnostics;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactoService _contactoService;

        public HomeController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Contacto> queryContactoSQl = await _contactoService.ObtenerTodo();
            List<VMContacto> lista = queryContactoSQl.Select(c => new VMContacto()
            {
                IdContacto = c.IdContacto,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                FechaNacimiento = c.FechaNacimiento.Value.ToString("g")
            }).ToList();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMContacto contacto)
        {
            Contacto NuevoModelo = new Contacto()
            {
                Nombre = contacto.Nombre,
                Telefono = contacto.Telefono,
                FechaNacimiento = DateTime.Parse(contacto.FechaNacimiento)
            };

            bool respuesta = await _contactoService.Insertar(NuevoModelo);

            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMContacto contacto)
        {
            Contacto NuevoModelo = new Contacto()
            {
                IdContacto = contacto.IdContacto,
                Nombre = contacto.Nombre,
                Telefono = contacto.Telefono,
                FechaNacimiento = DateTime.Parse(contacto.FechaNacimiento)
            };

            bool respuesta = await _contactoService.Actualizar(NuevoModelo);

            return Ok(respuesta);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _contactoService.Eliminar(id);

            return Ok(respuesta);
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
