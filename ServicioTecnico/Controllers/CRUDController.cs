using Microsoft.AspNetCore.Mvc;
using ServicioTecnico.Models;
using ServicioTecnico.Datos;

namespace ServicioTecnico.Controllers
{
    public class CRUDController : Controller
    {
        ClienteDatos clientesDatos = new ClienteDatos();
        ServicioDatos servicioDatos = new ServicioDatos();

        // Listar --------------------------------------

        public IActionResult Listar()
        {
            var oLista = clientesDatos.Listar();
            return View(oLista);
        }

        public IActionResult VerServicios(int id)
        {
            var oLista = servicioDatos.ObtenerTodos(id);
            return View(oLista);
        }

        public IActionResult ListarTodosLosServicios()
        {
            var oLista = servicioDatos.Listar();
            return View(oLista);
        }

        // Guardar --------------------------------------

        public IActionResult IngresarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IngresarCliente(ModelCliente oCliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = clientesDatos.Guardar(oCliente);

            if (respuesta)
            {
                TempData["Mensaje"] = "Se agrego un nuevo cliente! ➤";
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult IngresarServicio(int id)
        {
            var oServicio = new ModelServicio();
            oServicio.idCliente = id;
            return View(oServicio);
        }

        [HttpPost]
        public IActionResult IngresarServicio(ModelServicio oServicio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = servicioDatos.Guardar(oServicio);

            if (respuesta)
            {
                TempData["Mensaje"] = "Se agrego un nuevo service! ➤";
                return RedirectToAction("ListarTodosLosServicios");
            }
            else
            {
                return View();
            }
        }

        // Editar --------------------------------------

        public IActionResult EditarCliente(int id)  
        {
            var oCliente = clientesDatos.Obtener(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(ModelCliente oCliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clientesDatos.Editar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult EditarServicio(int id)
        {
            var oServicio = servicioDatos.Obtener(id);
            return View(oServicio);
        }

        [HttpPost]
        public IActionResult EditarServicio(ModelServicio oServicio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = servicioDatos.Editar(oServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        // Eliminar --------------------------------------

        public IActionResult EliminarCliente(int id)
        {
            var oCliente = clientesDatos.Obtener(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult EliminarCliente(ModelCliente oCliente)
        {
            var respuesta = clientesDatos.Eliminar(oCliente.id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult EliminarServicio(int id)
        {
            var oServicio = servicioDatos.Obtener(id);
            return View(oServicio);
        }

        [HttpPost]
        public IActionResult EliminarServicio(ModelServicio oServicio)
        {
            var respuesta = servicioDatos.Eliminar(oServicio.id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
