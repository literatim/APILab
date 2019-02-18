namespace APILab.Inventory.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Quantity { get; set; }
    }
}