using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace CriminalCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodeController : DefaultController<CriminalCodes, CriminalCodesRepository>
    {
        private readonly CriminalCodesRepository repository;
        public CriminalCodeController(CriminalCodesRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Authorize]
        public async override Task<ActionResult<CriminalCodes>> Post(CriminalCodes entity) {
            return await repository.AddCriminalCode(entity);
        }
    }
}
