using ShoppingList.Domain.Repository;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingList.Service.WebApi.Controllers
{
    [RoutePrefix("api/ShoppingList")]
    public class ShoppingListController : ApiController
    {
        private IRepository<Domain.Model.ShoppingList> shoppingListRepository;

        public ShoppingListController(IRepository<Domain.Model.ShoppingList> shoppingListRepository)
        {
            this.shoppingListRepository = shoppingListRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await shoppingListRepository.Set.Include(a => a.Items).Include("Items.ItemProduct").ToListAsync();
            return Ok(response);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IHttpActionResult> Post([FromBody]Domain.Model.ShoppingList request)
        {
            try
            {
                request.Date = DateTime.Now;
                await shoppingListRepository.AddAsync(request);
                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false); 
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IHttpActionResult> Put([FromBody]Domain.Model.ShoppingList request)
        {
            try
            {
                request.Date = DateTime.Now;
                await shoppingListRepository.AddOrUpdateAsync(request, request.Id);
                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }
    }
}
