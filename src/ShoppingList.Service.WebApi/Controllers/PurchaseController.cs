using ShoppingList.Domain.Model;
using ShoppingList.Domain.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingList.Service.WebApi.Controllers
{
    [RoutePrefix("api/Purchase")]
    public class PurchaseController : ApiController
    {
        private IRepository<Purchase> purchaseRepository;

        public PurchaseController(IRepository<Purchase> purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await purchaseRepository.Set.ToListAsync();
            return Ok(response);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IHttpActionResult> Post([FromBody]Purchase request)
        {
            request.Date = DateTime.Now;
            request.Total = request.Items.Sum(a => a.Price);
            var products = await purchaseRepository.AddAsync(request);
            return Ok(products);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IHttpActionResult> Put([FromBody]Purchase request)
        {
            request.Date = DateTime.Now;
            var products = await purchaseRepository.AddOrUpdateAsync(request, request.Id);
            return Ok(products);
        }
    }
}
