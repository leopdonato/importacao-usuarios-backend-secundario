using ImportacaoUsuarios.DTO;
using ImportacaoUsuarios.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Services
{
    public interface IUsuarioService
    {
        UsuariosDTO Insert();
        List<Usuarios> FindAll();
        Usuarios FindById(int Id);
        void InsertIntermediario(IFormFile file);
        void DeleteAllIntermediario();
    }
}
