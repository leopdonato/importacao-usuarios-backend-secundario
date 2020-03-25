using ImportacaoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImportacaoUsuarios.Services
{
    public interface IUsuarioIntermediarioService
    {
        void Insert(IFormFile file);
        List<UsuariosIntermediario> FindAll();
        void DeleteAll();
    }
}
