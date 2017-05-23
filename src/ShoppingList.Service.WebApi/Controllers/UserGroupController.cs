using ShoppingList.Domain.Model;
using ShoppingList.Domain.Repository;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingList.Service.WebApi.Controllers
{
    [RoutePrefix("api/UserGroup")]
    public class UserGroupController : ApiController
    {
        private IRepository<UserGroup> userGroupRepository;

        public UserGroupController(IRepository<UserGroup> userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            var response = await userGroupRepository.Set.ToListAsync();
            return Ok(response);
        }
    }
}
