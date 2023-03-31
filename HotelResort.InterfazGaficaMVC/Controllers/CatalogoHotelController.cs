using HotelResort.EntidadDeNegocio;
using HotelResort.LogicaDeNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelResort.InterfazGaficaMVC.Controllers
{
    public class CatalogoHotelController : Controller
    {
        CatalogoHotelBL catalogoBL = new CatalogoHotelBL();
        // GET: ClienteController
        public async Task<IActionResult> Index(CatalogoHotel pCatalogoH = null)
        {
            if (pCatalogoH == null)
                pCatalogoH = new CatalogoHotel();
            if (pCatalogoH.top_aux == 0)
                pCatalogoH.top_aux = 10;
            else if (pCatalogoH.top_aux == -1)
                pCatalogoH.top_aux = 0;

            var catalogo = await catalogoBL.BuscarAsync(pCatalogoH);
            ViewBag.Top = pCatalogoH.top_aux;
            return View(catalogo);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var catalogo = await catalogoBL.ObtenerPorIdAsync(new CatalogoHotel { Id = id });
            return View(catalogo);
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
        public async Task<IActionResult> Create(CatalogoHotel pCatalogoH)
        {
            try
            {
                int result = await catalogoBL.CrearAsync(pCatalogoH);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCatalogoH);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(CatalogoHotel pCatalogoH)
        {
            var catalogo = await catalogoBL.ObtenerPorIdAsync(pCatalogoH);
            ViewBag.Error = "";
            return View(catalogo);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CatalogoHotel pCatalogoH)
        {
            try
            {
                int result = await catalogoBL.ModificarAsync(pCatalogoH);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCatalogoH);
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(CatalogoHotel pCatalogoH)
        {
            ViewBag.Error = "";
            var catalogo = await catalogoBL.ObtenerPorIdAsync(pCatalogoH);
            return View(catalogo);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CatalogoHotel pCatalogoH)
        {
            try
            {
                int result = await catalogoBL.EliminarAsync(pCatalogoH);
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
