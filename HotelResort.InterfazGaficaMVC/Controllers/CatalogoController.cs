using HotelResort.EntidadDeNegocio;
using HotelResort.LogicaDeNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelResort.InterfazGaficaMVC.Controllers
{
    public class CatalogoController : Controller
    {
        CatalogoHotelBL catalogoBL = new CatalogoHotelBL();
        ReservacionBL reservacionBL = new ReservacionBL();
        // GET: CatalogoController
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

        // GET: CatalogoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var catalogo = await catalogoBL.ObtenerPorIdAsync(new CatalogoHotel { Id = id });
            return View(catalogo);
        }

        // GET: CatalogoController/Create
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


        // GET: CatalogoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetCatalogo(CatalogoHotel pCatalogo)
        {
            var catalogoBl = new CatalogoHotelBL();
           var cat =  catalogoBl.ObtenerPorIdAsync(pCatalogo);
            return Json(cat);
         }

    }
}
