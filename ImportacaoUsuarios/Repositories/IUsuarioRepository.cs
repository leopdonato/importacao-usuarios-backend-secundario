using ImportacaoUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Repositories
{
    public interface IUsuarioRepository
    {
        Usuarios Insert(Usuarios usuarios);
        List<Usuarios> FindAll();
        Usuarios FindById(int id);
        Usuarios FindByEmail(string email);
        Usuarios Update(Usuarios usuarios);
    }
}
