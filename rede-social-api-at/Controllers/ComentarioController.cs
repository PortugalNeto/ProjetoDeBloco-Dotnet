using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.ComentarioRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _iComentarioRepository;

        public ComentarioController(ApiDbContext apiDbContext, IComentarioRepository iComentarioRepository)
        {
            _iComentarioRepository = iComentarioRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            if (id == 0)
            {
                var coment = _iComentarioRepository.GetAll();
                return Ok(coment);
            }
            var outro = _iComentarioRepository.GetById(id);
            return Ok(outro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comentario coment)
        {
            _iComentarioRepository.CriarComentario(coment);
            return Ok(coment);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            var coment = _iComentarioRepository.GetById(id);
            _iComentarioRepository.Delete(coment);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Comentario comentario)
        {
            _iComentarioRepository.Update(id, comentario);
            return Ok(comentario);
        }
    }
}
