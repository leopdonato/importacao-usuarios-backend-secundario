using ImportacaoUsuarios.Models;
using ImportacaoUsuarios.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacaoUsuarios.Repositories.Implementations
{
    public class UsuarioRepositoryImp : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepositoryImp(UsuarioContext context)
        {
            _context = context;
        }
        public Usuarios Insert(Usuarios usuarios)
        {
            try
            {
                _context.Add(usuarios);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usuarios;
        }

        public List<Usuarios> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuarios FindById(int id)
        {
            return _context.Usuarios.SingleOrDefault(u => u.Id == id);
        }

        public Usuarios FindByEmail(string email)
        {
            return _context.Usuarios.SingleOrDefault(u => u.Email == email);
        }

        public Usuarios Update(Usuarios usuarios)
        {
            var result = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(usuarios.Id));
            try
            {
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(usuarios);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;

        }
    }
}
