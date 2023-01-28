using TechTest_PaymentApi.Models.Enums;

namespace TechTest_PaymentApi.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public Seller Seller { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string[] Items { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.AguarandoPagamento;
    }
}