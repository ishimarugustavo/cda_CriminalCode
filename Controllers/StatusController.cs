using Microsoft.AspNetCore.Mvc;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories;

namespace CriminalCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : DefaultController<Status, StatusRepository>
    {
        public StatusController(StatusRepository repository) : base(repository)
        {

        }
    }
}
