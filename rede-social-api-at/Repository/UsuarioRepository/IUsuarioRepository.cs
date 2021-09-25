using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.Models;

namespace rede_social_api_at.Repository.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        void SalvarUsuario(Usuario usuario);

        Usuario GetById(int usuarioId);
    }
}