using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories;

namespace CriminalCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodeController : DefaultController<CriminalCodes, CriminalCodesRepository>
    {
        public CriminalCodeController(CriminalCodesRepository repository) : base(repository)
        {

        }
    }
}
