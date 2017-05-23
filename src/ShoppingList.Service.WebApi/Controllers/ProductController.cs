using ShoppingList.Domain.Model;
using ShoppingList.Domain.Repository;
using ShoppingList.Service.WebApi.Helper;
using ShoppingList.Service.WebApi.Models.Dto;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingList.Service.WebApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IRepository<Product> productRepostiry;

        public ProductController(IRepository<Product> productRepostiry)
        {
            this.productRepostiry = productRepostiry;
        }

        [HttpGet]
        [Route("Get")]
        public  async Task<IHttpActionResult> Get()
        {
            var products = await productRepostiry.Set.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IHttpActionResult> Post([FromBody]Product request)
        {
            try
            {
                if (!await ValidateName(request))
                {
                    request.Date = DateTime.Now;
                    var products = await productRepostiry.AddAsync(request);
                    return Ok(true); 
                }
                else
                {
                    return Ok(request);
                }
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IHttpActionResult> Put([FromBody]Product request)
        {
            request.Date = DateTime.Now;
            var products = await productRepostiry.AddOrUpdateAsync(request, request.Id);
            return Ok(products);
        }

        private async Task<bool> ValidateName(Product request)
        {
            var exist = await productRepostiry.Set.AnyAsync(a => a.Name.ToLower() == request.Name.ToLower());
            return exist;
        }
    }
}
