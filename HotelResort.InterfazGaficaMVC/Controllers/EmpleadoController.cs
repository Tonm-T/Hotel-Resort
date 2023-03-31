using HotelResort.LogicaDeNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelResort.EntidadDeNegocio;
using System.Diagnostics.Contracts;
using HotelResort.AccesoADatos;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims; 

namespace HotelResort.InterfazGaficaMVC.Controllers
{
    //se pone para proteger todas las acciones por eso se pone al principio por el inicio de secion
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class EmpleadoController : Controller
    {
        EmpleadoBL empleadoBL = new EmpleadoBL();
        TipoCargoBL TipoCargoBL = new TipoCargoBL();
        // Accion para mostrar la pagina principal de usuarios
        public async Task<IActionResult> Index(Empleado pEmpleado = null)
        {
            if (pEmpleado == null)
                pEmpleado = new Empleado();
            if (pEmpleado.top_aux == 0)
                pEmpleado.top_aux = 10;
            else if (pEmpleado.top_aux == -1)
                pEmpleado.top_aux = 0;

            var empleado = await empleadoBL.BuscarIncluirTipoCargoAsync(pEmpleado);
            ViewBag.Top = pEmpleado.top_aux;
            ViewBag.TipoCargo = await TipoCargoBL.ObtenerTodosAsync();
            return View(empleado);
        }

        // Accion que muestra el detalle de un registro existente
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(new Empleado { Id = id });
            empleado.TipoCargo  = await TipoCargoBL.ObtenerPorIdAsync(new TipoCargo { Id = empleado.TipoCargoId });
            return View(empleado);
        }

        // accion que muestra el formulario para crear un nuevo Empleado
        public async Task<IActionResult> Create()
        {
            ViewBag.TipoCargo = await TipoCargoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // Accion qu recibe los datos del formulario para enviarlos ala BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.CrearAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ErrorInfo = ex.Message;
                ViewBag.TipoCargo = await TipoCargoBL.ObtenerTodosAsync();
                return View(pEmpleado);
            }
        }

        // Accion que muestra el formulario con los datos cargados para editar
        public async Task<IActionResult> Edit(Empleado pEmpleado)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            ViewBag.TipoCargo = await TipoCargoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Edit(int id, Empleado pEmpleado)
        {
            try
            {
                int resolt = await empleadoBL.ModificarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.TipoCargo = await TipoCargoBL.ObtenerTodosAsync();
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<IActionResult> Delete(Empleado pEmpleado)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            empleado.TipoCargo = await TipoCargoBL.ObtenerPorIdAsync(new TipoCargo { Id = pEmpleado.TipoCargoId });
            ViewBag.Error = "";
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.EliminarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
                if (empleado == null)
                    empleado = new Empleado();
                if (empleado.Id > 0)
                    empleado.TipoCargo = await TipoCargoBL.ObtenerPorIdAsync(new TipoCargo { Id = empleado.TipoCargoId });
                return View();
            }
        }

        // Accion que muestra la pagina de inicio de sesion
        [AllowAnonymous]
        public async Task<IActionResult> Login(string ReturnUrl = null)
        {
            //es para cerar secion que este abierta con la misma cuenta
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Url = ReturnUrl;
            ViewBag.Error = "";
            return View();
        }

        // Accion que recibe los datos para iniciar sesion
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Empleado pEmpleado, string pReturnUrl = null)
        {
            try
            {
                var empleado = await empleadoBL.LoginAsync(pEmpleado);
                if (empleado != null && empleado.Id > 0 && pEmpleado.Dui == empleado.Dui)
                {
                    empleado.TipoCargo = await TipoCargoBL.ObtenerPorIdAsync(new TipoCargo { Id = empleado.TipoCargoId });
                    var claims = new[] { new Claim(ClaimTypes.Name, empleado.Dui), new Claim(ClaimTypes.Role, empleado.TipoCargo.Cargo) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                }
                else
                    throw new Exception("Credenciales incorrectas");
                if (!string.IsNullOrWhiteSpace(pReturnUrl))
                    return Redirect(pReturnUrl);
                else
                    return RedirectToAction("Index", "AdminLogin");
            }
            catch (Exception ex)
            {
                ViewBag.Url = pReturnUrl;
                ViewBag.Error = ex.Message;
                return View(new Empleado { Dui = pEmpleado.Dui });
            }
        }
        //Accion que ejecuta el procedimiento de cierre de sesion
        [AllowAnonymous]
        public async Task<IActionResult> CerrarSesion(string ReturnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Empleado");
        }
        // Accion que muestra el formulario para cambiar la contraseña
        public async Task<IActionResult> CambiarPassword()
        {

            var empleados = await empleadoBL.BuscarAsync(new Empleado { Dui = User.Identity.Name, top_aux = 1 });
            var empleadoActual = empleados.FirstOrDefault();
            ViewBag.Error = "";
            return View(empleadoActual);
        }

        //Accion que recibe los cambios en la contraña para registrarlos en la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarPassword(Empleado pEmpleado, string pPasswordAnt)
        {
            try
            {
                int result = await empleadoBL.CambiarPasswordAsync(pEmpleado, pPasswordAnt);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("CambiarPassword", "Empleado");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var empleados = await empleadoBL.BuscarAsync(new Empleado { Dui = User.Identity.Name, top_aux = 1 });
                var empleadoActual = empleados.FirstOrDefault();
                return View(empleadoActual);
            }
        }
    }
}
