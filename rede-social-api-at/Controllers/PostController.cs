using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.PostRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _iPostRepository;

        public PostController(ApiDbContext apiDbContext, IPostRepository iPostRepository)
        {
            _iPostRepository = iPostRepository;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            if (id == 0)
            {
            var post = _iPostRepository.GetAll();
            return Ok(post);
            }
            var outro = _iPostRepository.GetById(id);
            return Ok(outro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            _iPostRepository.CriarPost(post);
            return Ok(post);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            var post = _iPostRepository.GetById(id);
            _iPostRepository.Delete(post);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Post post)
        {
            _iPostRepository.Update(id, post);
            return Ok(post);
        }
    }
}
