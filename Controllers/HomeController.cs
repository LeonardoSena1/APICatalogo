using APICatalogo.ApiKey;
using APICatalogo.Helper;
using APICatalogo.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductModel>> GetProduct()
        {
            return SqlServer.GetProduct();
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductModel>>> CreateProduct([FromBody] Product model)
        {
            if (model == null)
                return BadRequest("Produto vazio.");

            if (!string.IsNullOrEmpty(model.Title) && model.Price > 0)
            {
                SqlServer.InsertProduct(model.Title, model.Price);
            }
            else
            {
                return BadRequest("Titulo vazio ou preço zerado");
            }

            return Ok("Produto inserido");
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductModel>>> UpdateProduct([FromBody] Product model)
        {
            if (model == null)
                return BadRequest("Produto vazio.");

            if (!string.IsNullOrEmpty(model.Title) && model.Price > 0)
            {
                SqlServer.UpdateProduct(model.Title, model.Price, model.IdProduct);
            }
            else
            {
                return BadRequest("Titulo vazio ou preço zerado");
            }

            return Ok("Produto Atualizado");
        }

        [HttpDelete]
        public async Task<ActionResult<List<ProductModel>>> DelteProduct(int Id)
        {
            SqlServer.DeleteProduct(Id);

            return Ok("Produto Deletado");
        }
    }
}
