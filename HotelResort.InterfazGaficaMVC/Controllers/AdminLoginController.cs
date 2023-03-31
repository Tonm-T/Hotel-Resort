using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelResort.InterfazGaficaMVC.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminLoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminLoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminLoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminLoginController/Edit/5
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

        // GET: AdminLoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminLoginController/Delete/5
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
    }
}
