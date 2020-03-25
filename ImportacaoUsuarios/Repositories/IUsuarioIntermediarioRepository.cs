using ImportacaoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Repositories
{
    public interface IUsuarioIntermediarioRepository
    {
        UsuariosIntermediario Insert(UsuariosIntermediario usuariosIntermediario);
        List<UsuariosIntermediario> FindAll();
        void DeleteAll();
    }
}
