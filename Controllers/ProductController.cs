using APICatalogo.ApiKey;
using APICatalogo.Helper;
using APICatalogo.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    //[ApiKey]
    [ApiController]
    [Route("[controller]/v1/api")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductModel>> GetProduct()
        {
            return SqlServer.GetProduct();
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductModel>>> CreateProduct([FromBody] Product model)
        {
            //Valida erro Json
            if (model.Invalid)
            {
                //Insert errorMenssage in List
                var ret = new List<string>();
                model.ValidationResult.Errors.ForEach(x => ret.Add(x.ErrorMessage));

                //Join in list errormenssage
                var retorno = new Dictionary<string, string>();
                retorno.Add("Erro: ", string.Join(", ", ret));

                return BadRequest(JsonConvert.SerializeObject(retorno));
            }

            SqlServer.InsertProduct(model.Title, model.Price);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductModel>>> UpdateProduct([FromBody] Product model)
        {
            //Valida erro Json
            if (model.Invalid)
            {
                //Insert errorMenssage in List
                var ret = new List<string>();
                model.ValidationResult.Errors.ForEach(x => ret.Add(x.ErrorMessage));

                //Join in list errormenssage
                var retorno = new Dictionary<string, string>();
                retorno.Add("Erro: ", string.Join(", ", ret));

                return BadRequest(JsonConvert.SerializeObject(retorno));
            }

            SqlServer.UpdateProduct(model.Title, model.Price, model.Id);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<List<ProductModel>>> DelteProduct([FromBody] Product model)
        {
            //Valida erro Json
            if (model.Invalid)
            {
                //Insert errorMenssage in List
                var ret = new List<string>();
                model.ValidationResult.Errors.ForEach(x => ret.Add(x.ErrorMessage));

                //Join in list errormenssage
                var retorno = new Dictionary<string, string>();
                retorno.Add("Erro: ", string.Join(", ", ret));

                return BadRequest(JsonConvert.SerializeObject(retorno));
            }

            SqlServer.DeleteProduct(model.IdProduct);

            return Ok();
        }

        [HttpPost]
        [Route("idproduct/{id}")]
        public async Task<ActionResult<List<ProductModel>>> GetByIdProduct(int Id)
        {
            if (Id > 0)
            {
                return Ok(JsonConvert.SerializeObject(SqlServer.GetProductById(Id)));
            }

            return BadRequest();
        }
    }
}
