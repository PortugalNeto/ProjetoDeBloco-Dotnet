using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.UsuarioRepository;

namespace rede_social_api_at.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;


        public UsuarioController(ApiDbContext apiDbContext, IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
          var usuarios =  _iUsuarioRepository.GetAll();
          return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public Usuario Get(int id)
        {
            var usuario = _iUsuarioRepository.GetById(id);
            
            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _iUsuarioRepository.SalvarUsuario(usuario);
            return Ok(usuario);

        }
        
      
    }
}
