using HotelResort.EntidadDeNegocio;
using HotelResort.LogicaDeNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelResort.InterfazGaficaMVC.Controllers
{
    public class ReservacionController : Controller
    {
        ReservacionBL reservacionBL = new ReservacionBL();
        // GET:Controller
        public async Task<IActionResult> Index(Reservacion pReservacion = null)
        {
            if (pReservacion == null)
                pReservacion = new Reservacion();
            if (pReservacion.top_aux == 0)
                pReservacion.top_aux = 10;
            else if (pReservacion.top_aux == -1)
                pReservacion.top_aux = 0;

            var reservacion = await reservacionBL.BuscarAsync(pReservacion);
            ViewBag.Top = pReservacion.top_aux;
            return View(reservacion);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reservacion = await reservacionBL.ObtenerPorIdAsync(new Reservacion { Id = id });
            return View(reservacion);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservacion pReservacion)
        {
            try
            {
                int result = await reservacionBL.CrearAsync(pReservacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pReservacion);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(Reservacion pReservacion)
        {
            var reservacion = await reservacionBL.ObtenerPorIdAsync(pReservacion);
            ViewBag.Error = "";
            return View(reservacion);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservacion pReservacion)
        {
            try
            {
                int result = await reservacionBL.ModificarAsync(pReservacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pReservacion);
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(Reservacion pReservacion)
        {
            ViewBag.Error = "";
            var reservacion = await reservacionBL.ObtenerPorIdAsync(pReservacion);
            return View(reservacion);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Reservacion pReservacion)
        {
            try
            {
                int result = await reservacionBL.EliminarAsync(pReservacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
