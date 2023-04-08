using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelResort.EntidadDeNegocio;
using HotelResort.LogicaDeNegocio;
using System.Diagnostics.Contracts;

namespace HotelResort.InterfazGaficaMVC.Controllers
{
    public class TipoCargoController : Controller
    {
        TipoCargoBL TipoCargoBL = new TipoCargoBL();
        // GET: TipoCargoController
        public async Task<IActionResult> Index(TipoCargo pTipoCargo = null)
        {
            if (pTipoCargo == null)
                pTipoCargo = new TipoCargo();
            if (pTipoCargo.top_aux == 0)
                pTipoCargo.top_aux = 10;
            else if (pTipoCargo.top_aux == -1)
                pTipoCargo.top_aux = 0;

            var tipocargo = await TipoCargoBL.BuscarAsync(pTipoCargo);
            ViewBag.Top = pTipoCargo.top_aux;
            return View(tipocargo);
        }

        // GET: TipoCargoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tipocargo = await TipoCargoBL.ObtenerPorIdAsync(new TipoCargo { Id = id });
            return View(tipocargo);
        }

        // GET: TipoCargoController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: TipoCargoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoCargo pTipoCargo)
        {
            try
            {
                int result = await TipoCargoBL.CrearAsync(pTipoCargo);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ErrorInfo = ex.Message;
                return View(pTipoCargo);
            }
        }

        // GET: TipoCargoController/Edit/5
        public async Task<IActionResult> Edit(TipoCargo pTipoCargo)
        {
            var tipocargo = await TipoCargoBL.ObtenerPorIdAsync(pTipoCargo);
            ViewBag.Error = "";
            return View(tipocargo);
        }

        // POST: TipoCargoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoCargo pTipoCargo)
        {
            try
            {
                int result = await TipoCargoBL.ModificarAsync(pTipoCargo);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pTipoCargo);
            }
        }

        // GET: TipoCargoController/Delete/5
        public async Task<IActionResult> Delete(TipoCargo pTipoCargo)
        {
            var TipoCargo = await TipoCargoBL.ObtenerPorIdAsync(pTipoCargo);
            ViewBag.Error = "";
            return View(TipoCargo);
        }

        // Acción que recibe la confirmación para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TipoCargo pTipoCargo)
        {
            try
            {
                int result = await TipoCargoBL.EliminarAsync(pTipoCargo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pTipoCargo);
            }
        }
    }
}
