using Microsoft.AspNetCore.Mvc;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories;
using System.Threading.Tasks;
using CriminalCode.API.Services;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace CriminalCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UsersRepository usersRepository;
        public UserController(UsersRepository repository)
        {
            this.usersRepository = repository;
        }
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(User user)
        {
            var entity = usersRepository.loginUser(user);
            if (entity == null) 
                return NotFound(new { message = "Usuário ou senha inválidos" });
            
            var token = TokenService.GenerateToken(user);
            entity.Password = "";

            return new 
            {
                user = entity,
                token = token
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post(User entity)
        {
            var existUser = usersRepository.findUserByUserName(entity.UserName);
            if (existUser != null)
                return BadRequest(new { message = "Já existe um usuário com o mesmo Nome." });

            await usersRepository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await usersRepository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> Get(int id)
        {
            var entity = await usersRepository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}