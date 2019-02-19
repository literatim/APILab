using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using APILab.eCommerce.DAL;
using APILab.eCommerce.Models;

namespace APILab.eCommerce.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["Id"] = id;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.Inventory inventory)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:32534/");
            var response = await client.PutAsJsonAsync($"api/inventories/{inventory.Id}", inventory);

            return RedirectToAction("Details", new {inventory.Id });
        }
    }
}
