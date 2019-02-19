using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APILab.Inventory.DAL;
using System.Web.Http.Cors;

namespace APILab.Inventory.Controllers
{
    [EnableCors("*", "*", "*")]
    public class InventoriesController : ApiController
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: api/Inventories
        public IQueryable<Models.Inventory> GetInventories()
        {
            return db.Inventories;
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Models.Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Models.Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // POST: api/Inventories
        [ResponseType(typeof(Models.Inventory))]
        public async Task<IHttpActionResult> PostInventory(Models.Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventories.Add(inventory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inventory.Id }, inventory);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}