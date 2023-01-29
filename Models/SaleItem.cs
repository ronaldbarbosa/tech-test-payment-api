namespace TechTest_PaymentApi.Models
{
    public class SaleItem
    {
        public int SaleItemId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}