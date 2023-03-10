using Microsoft.AspNetCore.Mvc;
using TechTest_PaymentApi.Models;
using TechTest_PaymentApi.Context;
using TechTest_PaymentApi.Models.Enums;

namespace TechTest_PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesApiController : ControllerBase
    {
        private readonly SalesContext _context;
        public SalesApiController(SalesContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult SearchSale(int id)
        {
            var sale = _context.Sales.Find(id);

            if (sale == null)
            {
                return NotFound();
            }

            // Nas próximas 3 linhas eu fiz essa "gambiarra" porque no retorno do Db, o objeto "sale" ficava com os atributos 
            // Seller e Item com o valor null.
            // To do: procurar o jeito certo de carregar esses atributos.
            sale.Seller = _context.Sellers.Find(sale.SellerId);
            sale.Item = _context.SaleItems.Find(sale.SaleItemId);
            sale.Item.Product = _context.Products.Find(sale.Item.ProductId);

            return Ok(sale);
        }

        [HttpPatch("{id}-{status}")]
        public IActionResult UpdateSale(int id, StatusEnum status)
        {
            if (status == null)
            {
                return StatusCode(400);
            }
            var sale = _context.Sales.Find(id);
            if(sale == null)
            {
                return NotFound();
            }

            switch (sale.Status)
            {
                case StatusEnum.AguardandoPagamento:
                    if (status == StatusEnum.PagamentoAprovado || status == StatusEnum.Cancelada)
                    {
                        sale.Status = status;
                    }
                    else
                    {
                        return StatusCode(400);
                    }
                    break;
                
                case StatusEnum.PagamentoAprovado:
                    if (status == StatusEnum.EnviadoParaTransportadora || status == StatusEnum.Cancelada)
                    {
                        sale.Status = status;
                    }
                    else
                    {
                        return StatusCode(400);
                    }
                    break;

                case StatusEnum.EnviadoParaTransportadora:
                    if (status == StatusEnum.Entregue)
                    {
                        sale.Status = StatusEnum.Entregue;
                    }
                    else
                    {
                        return StatusCode(400);
                    }
                    break;

                default:
                    return StatusCode(400);
            }
            
            _context.Sales.Update(sale);
            _context.SaveChanges();

            return Ok(sale);
        }

        [HttpPost]
        public IActionResult RegisterSale(Sale sale) 
        {
            if (sale.Item.Quantity < 1)
            {
                return StatusCode(400);
            }
            _context.Add(sale);
            _context.SaveChanges();
            return StatusCode(201, sale);
        }
    }
}