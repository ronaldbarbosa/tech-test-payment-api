using System.ComponentModel.DataAnnotations.Schema;
using TechTest_PaymentApi.Models.Enums;

namespace TechTest_PaymentApi.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public virtual Seller Seller { get; set; }
        public int SellerId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual SaleItem Item { get; set; }
        public int SaleItemId { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.AguardandoPagamento;
    }
}