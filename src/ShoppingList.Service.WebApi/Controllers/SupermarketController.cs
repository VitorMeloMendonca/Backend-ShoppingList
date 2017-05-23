using ShoppingList.Domain.Model;
using ShoppingList.Domain.Repository;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingList.Service.WebApi.Controllers
{
    [RoutePrefix("api/Supermarket")]
    public class SupermarketController : ApiController
    {
        private IRepository<Supermarket> supermarketRepository;

        public SupermarketController(IRepository<Supermarket> supermarketRepository)
        {
            this.supermarketRepository = supermarketRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await supermarketRepository.Set.ToListAsync();
            return Ok(response);
        }
    }
}
