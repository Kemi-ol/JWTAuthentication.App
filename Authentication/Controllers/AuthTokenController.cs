using Authentication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTokenController : ControllerBase
    {

        public IConfiguration _configuration;

        private readonly DatabaseContext _databaseContext;

       public AuthTokenController(DatabaseContext databaseContext,
           IConfiguration config)
        {
            _databaseContext = databaseContext;
            _configuration = config;
        }

      

    }
}
