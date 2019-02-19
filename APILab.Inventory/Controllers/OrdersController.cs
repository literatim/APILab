using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using APILab.Inventory.DAL;
using APILab.Inventory.Models;

namespace APILab.Inventory.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OrdersController : ApiController
    {
        private InventoryDbContext db = new InventoryDbContext();
        

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);

            db.Inventories.Find(order.ItemId);


            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
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