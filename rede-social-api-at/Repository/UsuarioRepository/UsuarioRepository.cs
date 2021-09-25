using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;

namespace rede_social_api_at.Repository.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiDbContext _dbContext;

        public UsuarioRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Usuario> GetAll()
        {
            var usuarios = _dbContext.Usuario.ToList();
            return usuarios;
        }

        public void SalvarUsuario(Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
        }

        public Usuario GetById(int usuarioId)
        {
            var usuarioById = _dbContext.Usuario.Find(usuarioId);
            return usuarioById;
        }
    }
}